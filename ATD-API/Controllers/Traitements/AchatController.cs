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
    public class AchatController : ControllerBase
    {
        private readonly IAchat _repository;
        private readonly IMouvement _mouvementRepository;
        private readonly IStock _stockRepository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;


        public AchatController(IAchat repository, IMapper mapper, MyDbContext myDbContext, IMouvement mouvementRepository, IStock stockRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
            _mouvementRepository = mouvementRepository;
            _stockRepository = stockRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Achat>> Add([FromBody] AchatDto request)
        {
            StockMod stock = new StockMod();
            AchatModel model = new AchatModel();

            Random random = new Random();
            int num = random.Next();

            model.numeroAchat = DateTime.Now.Year.ToString() + DateTime.Now.Month + num;
            model.periode = DateTime.Now.Month.ToString() + DateTime.Now.Year;
            model.locationId = request.locationId;
            model.utilisateurId = request.utilisateurId;
            model.fournisseurId = request.fournisseurId;
            model.numeroFacture = request.numeroFacture;
            model.dateAchat = request.dateAchat;
            model.montantTotal = request.montantTotal;
            model.tauxAchat = 1;
            model.detailAchats = request.detailAchats;

            var result = await _repository.AddAsync(_mapper.Map<Achat>(model));
            MouvementStock mouvement = new MouvementStock();


            foreach (var item in result.detailAchats)
            {

                //ajout dans le stock
                var query = await _myDbContext.article_stocks.FirstOrDefaultAsync(s => s.articleId == item.articleId && s.locationId == result.locationId);
                var emballage = await _myDbContext.emballageByArticles.FirstOrDefaultAsync(s => s.articleId == item.articleId);
                var article = await _myDbContext.articles.FirstOrDefaultAsync(s => s.id == item.articleId);

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
                mouvement.qteSt = query.quantite + mouvement.qteEntr;
                //  mouvement.emballage = emballage.emballageDetail;


                if (query == null)
                {
                    stock.locationId = result.locationId;
                    stock.articleId = item.articleId;
                    if (emballage != null && emballage.emballageGros == item.emballage)
                    {
                        stock.quantite = item.quantite * article.quantiteDetail;
                    }
                    else
                    {
                        stock.quantite = item.quantite;
                    }
                    await _stockRepository.AddAsync(_mapper.Map<Stock>(stock));
                }
                else
                {
                    if (emballage != null && emballage.emballageGros == item.emballage)
                    {
                        query.quantite += item.quantite * article.quantiteDetail;
                    }
                    else
                    {
                        query.quantite += item.quantite;
                    }

                    await _stockRepository.UpdateAsync(_mapper.Map<Stock>(query));

                }

                var res = _myDbContext.mouvementStocks.Add(mouvement);
                await _myDbContext.SaveChangesAsync();

                // await _mouvementRepository.AddAsync(_mapper.Map<Mouvement>(mouvement));

            }

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Achat>> Update(Guid id, [FromBody] AchatModel request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.dateAchat = request.dateAchat;
            query.numeroFacture = request.numeroFacture;
            query.numeroAchat = request.numeroAchat;
            query.fournisseurId = request.fournisseurId;
            query.locationId = request.locationId;
            query.montantTotal = request.montantTotal;
            query.tauxAchat = request.tauxAchat;
            query.detailAchats = request.detailAchats;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Achat>> FindAll(Guid id)
        {
            var items = await (from a in _myDbContext.achats.Include(d => d.detailAchats)
                               join f in _myDbContext.fournisseurs on a.fournisseurId equals f.id
                               join u in _myDbContext.utilisateurs on a.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id

                               select new
                               {

                                   id = a.id,
                                   dateAchat = a.dateAchat,
                                   numeroFacture = a.numeroFacture,
                                   locationId = a.locationId,
                                   location = l.designation,
                                   fournisseurId = a.fournisseurId,
                                   fournisseur = f.nom,
                                   tauxAchat = a.tauxAchat,
                                   montantTotal = a.montantTotal,
                                   numeroAchat = a.numeroAchat,
                                   utilisateurId = a.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   detailAchats = a.detailAchats

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

