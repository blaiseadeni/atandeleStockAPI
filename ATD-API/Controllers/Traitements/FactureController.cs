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
    public class FactureController : ControllerBase
    {
        private readonly IFacture _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;
        public FactureController(IFacture repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Facture>> Add([FromBody] FactureRequest request)
        {
            FactureMod facture = new FactureMod();
            MouvementMod mouvement = new MouvementMod();

            facture.NumeroFacture = request.NumeroFacture;

            facture.LocationId = request.LocationId;

            facture.Client = request.Client;

            facture.Taux = request.Taux;

            facture.Remise = request.Remise;

            facture.TotalHt = request.TotalHt;

            facture.MontantPayer = request.MontantPayer;

            facture.ResteApayer = request.ResteApayer;

            facture.Monnaie = request.Monnaie;

            facture.Paiement = request.Paiement;

            facture.Status = request.Status;

            facture.DetailFactures = request.DetailFactures;

            var result = await _repository.AddAsync(_mapper.Map<Facture>(facture));

            foreach (var item in result.DetailFactures)
            {
                var stock = _myDbContext.article_stocks.FirstOrDefault(s => s.ArticleId == item.ArticleId);
                var emballage = _myDbContext.emballageByArticles.FirstOrDefault(e => e.ArticleId == item.ArticleId);
                var article = _myDbContext.articles.FirstOrDefault(a => a.Id == item.ArticleId);

                mouvement.ArticleId = item.ArticleId;
                mouvement.Article = item.Article;
                mouvement.LocationId = result.LocationId;
                mouvement.Quantite = item.Quantite;
                mouvement.Type = "SORTIE";
                mouvement.Designation = "VENTE";
                mouvement.Emballage = item.Emballage;

                if (stock != null && emballage != null && article != null)
                {
                    if (item.Emballage == emballage.EmballageGros)
                    {
                        stock.Quantite -= item.Quantite * article.QuantiteDetail;
                    }
                    else
                    {
                        stock.Quantite -= item.Quantite;
                    }
                }
                _myDbContext.article_stocks.Update(stock);
                _myDbContext.mouvements.Add(_mapper.Map<Mouvement>(mouvement));
            }
            _myDbContext.SaveChanges();

            var client = _myDbContext.signaletiques.FirstOrDefault(c => c.Id == Guid.Parse(result.Client));
            var portefeuille = _myDbContext.portefeuilles.FirstOrDefault(p => p.clientId == Guid.Parse(result.Client));
            if (client != null && portefeuille != null)
            {
                if (request.Paiement == "PORTEFEUILLE")
                {
                    portefeuille.montant -= request.MontantPortefeuille;
                }
            }
            _myDbContext.portefeuilles.Update(portefeuille);
            _myDbContext.SaveChanges();
            return Ok("Saved successfullly");
        }


        [HttpGet]
        public async Task<ActionResult<Facture>> FindAll()
        {
            var items = await _repository.FindAllAsync();
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

