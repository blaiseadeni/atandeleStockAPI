using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
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
            MouvementStock mouvement = new MouvementStock();

            Random random = new Random();
            int num = random.Next();

            facture.numeroFacture = DateTime.Now.Year.ToString() + DateTime.Now.Month + num;
            facture.periode = DateTime.Now.Month.ToString() + DateTime.Now.Year;

            facture.locationId = request.locationId;

            facture.utilisateurId = request.utilisateurId;

            facture.client = request.client;

            facture.taux = 1;

            facture.remise = request.remise;

            facture.totalHt = request.totalHt;

            facture.montantPayer = request.montantPayer;

            facture.resteApayer = request.resteApayer;

            facture.monnaie = "UGX";

            facture.paiement = request.paiement;

            facture.status = request.status;

            facture.detailFactures = request.detailFactures;

            var result = await _repository.AddAsync(_mapper.Map<Facture>(facture));

            foreach (var item in result.detailFactures)
            {
                var stock = _myDbContext.article_stocks.FirstOrDefault(s => s.articleId == item.articleId);
                var emballage = _myDbContext.emballageByArticles.FirstOrDefault(e => e.articleId == item.articleId);
                var article = _myDbContext.articles.FirstOrDefault(a => a.id == item.articleId);


                mouvement.articleId = item.articleId;
                mouvement.article = item.article;
                mouvement.locationId = result.locationId;
                mouvement.puSort = item.prixUnit;
                mouvement.periode = result.periode;
                mouvement.date = DateTime.Now;
                mouvement.libelle = "Sorties";
                if (item.emballage == emballage.emballageGros)
                {
                    mouvement.qteSort = item.quantite * article.quantiteDetail;
                }
                else
                {
                    mouvement.qteSort = item.quantite;
                }
                //mouvement.type = "ENTRE";
                mouvement.ptSort = mouvement.qteSort * item.prixUnit;
                mouvement.qteSt = stock.quantite - mouvement.qteSort;
                //  mouvement.emballage = emballage.emballageDetail;

                if (stock != null && emballage != null && article != null)
                {
                    if (item.emballage == emballage.emballageGros)
                    {
                        stock.quantite -= item.quantite * article.quantiteDetail;
                    }
                    else
                    {
                        stock.quantite -= item.quantite;
                    }
                }
                _myDbContext.article_stocks.Update(stock);
                //   _myDbContext.mouvements.Add(_mapper.Map<Mouvement>(mouvement));
                var res = _myDbContext.mouvementStocks.Add(mouvement);
                await _myDbContext.SaveChangesAsync();
            }
            _myDbContext.SaveChanges();

            if (request.clientId != null)
            {
                var client = _myDbContext.signaletiques.FirstOrDefault(c => c.id == request.clientId);
                var portefeuille = _myDbContext.portefeuilles.FirstOrDefault(p => p.clientId == request.clientId);
                if (client != null && portefeuille != null)
                {
                    if (request.paiement == "PORTEFEUILLE")
                    {
                        portefeuille.montant -= request.montantPortefeuille;
                        _myDbContext.SaveChanges();
                        _myDbContext.portefeuilles.Update(portefeuille);
                    }
                }
            }

            return result;
        }


        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Facture>> FindAll(Guid id)
        {

            var items = await (from f in _myDbContext.factures.Include(d => d.detailFactures)
                               join u in _myDbContext.utilisateurs on f.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = f.id,
                                   numeroFacture = f.numeroFacture,
                                   locationId = f.locationId,
                                   utilisateurId = f.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   dateFacture = f.dateFacture,
                                   client = f.client,
                                   taux = f.taux,
                                   remise = f.remise,
                                   totalHt = f.totalHt,
                                   montantPayer = f.montantPayer,
                                   resteApayer = f.resteApayer,
                                   monnaie = f.monnaie,
                                   montantLettre = f.montantLettre,
                                   paiement = f.paiement,
                                   status = f.status,
                                   detailFactures = f.detailFactures,

                               }).ToListAsync();
            return Ok(items.DistinctBy(c => c.id));
        }

        [HttpGet("np/{id:Guid}")]
        public async Task<ActionResult<Facture>> FindAllNp(Guid id)
        {

            var items = await (from f in _myDbContext.factures.Include(d => d.detailFactures)
                               join u in _myDbContext.utilisateurs on f.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               where f.resteApayer > 0
                               select new
                               {
                                   id = f.id,
                                   numeroFacture = f.numeroFacture,
                                   locationId = f.locationId,
                                   utilisateurId = f.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   dateFacture = f.dateFacture,
                                   client = f.client,
                                   taux = f.taux,
                                   remise = f.remise,
                                   totalHt = f.totalHt,
                                   montantPayer = f.montantPayer,
                                   resteApayer = f.resteApayer,
                                   monnaie = f.monnaie,
                                   montantLettre = f.montantLettre,
                                   paiement = f.paiement,
                                   status = f.status,
                                   detailFactures = f.detailFactures,

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

