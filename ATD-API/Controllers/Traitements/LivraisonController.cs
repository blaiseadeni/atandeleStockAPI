using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Traitements
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivraisonController : ControllerBase
    {
        private readonly ILivraison _repository;
        private readonly IMapper _mapper;
        private readonly IMouvement _mouvementRepository;
        private readonly IStock _stockRepository;
        private readonly MyDbContext _myDbContext;

        public LivraisonController(ILivraison repository, IMapper mapper, MyDbContext myDbContext, IMouvement mouvementRepository, IStock stockRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
            _mouvementRepository = mouvementRepository;
            _stockRepository = stockRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Livraison>> Add([FromBody] LivraisonMod request)
        {
            Random random = new Random();
            int num = random.Next();
            request.numeroLivraison = DateTime.Now.Year.ToString() + DateTime.Now.Month + num;
            request.periode = DateTime.Now.Month.ToString() + DateTime.Now.Year;

            var result = await _repository.AddAsync(_mapper.Map<Livraison>(request));
            var query = await _myDbContext.commandes.Include(d => d.detailCommandes).FirstOrDefaultAsync(c => c.numeroCommande == result.numeroCommande);
            StockMod stock = new StockMod();

            //modification de la table commande
            foreach (var item in query.detailCommandes)
            {
                foreach (var item1 in result.detailLivraisons)
                {
                    item.quantiteLivree += item1.quantite;
                    item.resteQuantite = item.quantite - item.quantiteLivree;
                }
                _myDbContext.detailCommandes.Update(item);
            }

            //Ajout dans la table mouvement
            MouvementStock mouvement = new MouvementStock();
            foreach (var item in result.detailLivraisons)
            {

                //ajout dans le stock
                var req = await _myDbContext.article_stocks.FirstOrDefaultAsync(s => s.articleId == item.articleId);

                var article = await _myDbContext.articles.FirstOrDefaultAsync(a => a.id == item.articleId);
                var emballage = await _myDbContext.emballageByArticles.FirstOrDefaultAsync(a => a.articleId == item.articleId);

                mouvement.articleId = item.articleId;
                mouvement.article = item.article;
                mouvement.locationId = result.locationId;
                mouvement.puEntr = item.prixUnit;
                mouvement.periode = result.periode;
                mouvement.date = DateTime.Now;
                mouvement.libelle = "Entrées";
                if (item.emballage == emballage.emballageGros)
                {
                    mouvement.qteEntr = item.quantite * article.quantiteDetail;

                }
                else
                {
                    mouvement.qteEntr = item.quantite;
                }
                //mouvement.type = "ENTRE";
                mouvement.ptEnt = mouvement.qteEntr * item.prixUnit;
                mouvement.qteSt = req.quantite + mouvement.qteEntr;
                //  mouvement.emballage = emballage.emballageDetail;

                if (req == null)
                {
                    stock.locationId = result.locationId;
                    stock.articleId = item.articleId;
                    if (emballage.emballageGros != null && emballage.emballageGros == item.emballage)
                    {
                        stock.quantite += item.quantite * article.quantiteDetail;
                    }
                    else
                    {
                        stock.quantite += item.quantite;
                    }
                    await _stockRepository.AddAsync(_mapper.Map<Stock>(stock));
                }
                else
                {
                    if (emballage.emballageGros == item.emballage)
                    {
                        req.quantite += item.quantite * article.quantiteDetail;
                    }
                    else
                    {
                        req.quantite += item.quantite;
                    }
                    await _stockRepository.UpdateAsync(_mapper.Map<Stock>(req));

                }

                var res = _myDbContext.mouvementStocks.Add(mouvement);
                await _myDbContext.SaveChangesAsync();
                // var res = await _mouvementRepository.AddAsync(_mapper.Map<Mouvement>(mouvement));
            }

            await _myDbContext.SaveChangesAsync();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Livraison>> Update(Guid id, [FromBody] LivraisonMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.observation = request.observation;
            query.locationId = request.locationId;
            query.fournisseurId = request.fournisseurId;
            query.dateLivraison = request.dateLivraison;
            query.numeroCommande = request.numeroCommande;
            query.totalLivraison = request.totalLivraison;
            query.detailLivraisons = request.detailLivraisons;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Livraison>> FindAll(Guid id)
        {
            var items = await (from li in _myDbContext.livraisons.Include(d => d.detailLivraisons)
                               join lo in _myDbContext.locations on li.locationId equals lo.id
                               join f in _myDbContext.fournisseurs on li.fournisseurId equals f.id
                               join u in _myDbContext.utilisateurs on li.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               select new
                               {

                                   id = li.id,
                                   numeroLivraison = li.numeroLivraison,
                                   numeroCommande = li.numeroCommande,
                                   dateLivraison = li.dateLivraison,
                                   fournisseurId = li.fournisseurId,
                                   fournisseur = f.nom,
                                   observation = li.observation,
                                   locationId = li.locationId,
                                   location = lo.designation,
                                   utilisateurId = li.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   totalLivraison = li.totalLivraison,
                                   detailLivraisons = li.detailLivraisons

                               }).ToListAsync();
            return Ok(items.DistinctBy(c => c.id));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}

