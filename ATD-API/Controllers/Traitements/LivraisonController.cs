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
            var result = await _repository.AddAsync(_mapper.Map<Livraison>(request));
            var query = await _myDbContext.commandes.Include(d => d.DetailCommandes).FirstOrDefaultAsync(c => c.NumeroCommande == result.NumeroCommande);
            StockMod stock = new StockMod();
            //modification de la table commande
            foreach (var item in query.DetailCommandes)
            {
                foreach (var item1 in result.DetailLivraisons)
                {
                    item.QuantiteLivree += item1.Quantite;
                    item.ResteQuantite = item.Quantite - item.QuantiteLivree;
                }
                _myDbContext.detailCommandes.Update(item);
            }

            //Ajout dans la table mouvement
            MouvementMod mouvement = new MouvementMod();
            foreach (var item in result.DetailLivraisons)
            {
                mouvement.ArticleId = item.ArticleId;
                mouvement.Article = item.Article;
                mouvement.LocationId = result.LocationId;
                mouvement.Quantite = item.Quantite;
                mouvement.Type = "ENTRE";
                mouvement.Designation = "LIVRAISON";
                mouvement.Emballage = item.Emballage;
                //ajout dans le stock
                var req = await _myDbContext.article_stocks.FirstOrDefaultAsync(s => s.ArticleId == item.ArticleId);

                var article = await _myDbContext.articles.FirstOrDefaultAsync(a => a.Id == item.ArticleId);
                var emballage = await _myDbContext.emballageByArticles.FirstOrDefaultAsync(a => a.ArticleId == item.ArticleId);
                if (req == null)
                {
                    stock.LocationId = result.LocationId;
                    stock.ArticleId = item.ArticleId;
                    if (emballage.EmballageGros != null && emballage.EmballageGros == item.Emballage)
                    {
                        stock.Quantite += item.Quantite * article.QuantiteDetail;
                    }
                    else
                    {
                        stock.Quantite += item.Quantite;
                    }
                    await _stockRepository.AddAsync(_mapper.Map<Stock>(stock));
                }
                else
                {
                    if (emballage.EmballageGros == item.Emballage)
                    {
                        req.Quantite += item.Quantite * article.QuantiteDetail;
                    }
                    else
                    {
                        req.Quantite += item.Quantite;
                    }
                    await _stockRepository.UpdateAsync(_mapper.Map<Stock>(req));

                }
                var res = await _mouvementRepository.AddAsync(_mapper.Map<Mouvement>(mouvement));
            }

            await _myDbContext.SaveChangesAsync();
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Livraison>> Update(Guid id, [FromBody] LivraisonMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.Observation = request.Observation;
            query.LocationId = request.LocationId;
            query.FournisseurId = request.FournisseurId;
            query.DateLivraison = request.DateLivraison;
            query.MonnaieId = request.MonnaieId;
            query.NumeroCommande = request.NumeroCommande;
            query.DetailLivraisons = request.DetailLivraisons;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Livraison>> FindAll()
        {
            var items = await (from li in _myDbContext.livraisons.Include(d => d.DetailLivraisons)
                               join lo in _myDbContext.locations on li.LocationId equals lo.Id
                               join f in _myDbContext.fournisseurs on li.FournisseurId equals f.Id
                               join m in _myDbContext.monnaies on li.MonnaieId equals m.Id

                               select new LivraisonList()
                               {

                                   Id = li.Id,
                                   NumeroLivraison = li.NumeroLivraison,
                                   NumeroCommande = li.NumeroCommande,
                                   DateLivraison = li.DateLivraison,
                                   FournisseurId = li.FournisseurId,
                                   Fournisseur = f.Nom,
                                   Observation = li.Observation,
                                   LocationId = li.LocationId,
                                   Location = lo.Designation,
                                   MonnaieId = li.MonnaieId,
                                   Monnaie = m.Devise,
                                   DetailLivraisons = li.DetailLivraisons

                               }).ToListAsync();
            return Ok(items);
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

