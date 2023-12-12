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
        public async Task<ActionResult<Achat>> Add([FromBody] AchatModel request)
        {

            var result = await _repository.AddAsync(_mapper.Map<Achat>(request));
            MouvementMod mouvement = new MouvementMod();
            StockMod stock = new StockMod();
            foreach (var item in result.DetailAchats)
            {
                mouvement.ArticleId = item.ArticleId;
                mouvement.Article = item.Article;
                mouvement.LocationId = result.LocationId;
                mouvement.Quantite = item.Quantite;
                mouvement.Type = "ENTRE";
                mouvement.Designation = "ACHAT";
                mouvement.Emballage = item.Emballage;
                //ajout dans le stock
                var query = await _myDbContext.article_stocks.FirstOrDefaultAsync(s => s.ArticleId == item.ArticleId && s.LocationId == result.LocationId);
                var emballage = await _myDbContext.emballageByArticles.FirstOrDefaultAsync(s => s.ArticleId == item.ArticleId);
                var article = await _myDbContext.articles.FirstOrDefaultAsync(s => s.Id == item.ArticleId);
                if (query == null)
                {
                    stock.LocationId = result.LocationId;
                    stock.ArticleId = item.ArticleId;
                    if (emballage != null && emballage.EmballageGros == item.Emballage)
                    {
                        stock.Quantite = item.Quantite * article.QuantiteDetail;
                    }
                    else
                    {
                        stock.Quantite = item.Quantite;
                    }
                    await _stockRepository.AddAsync(_mapper.Map<Stock>(stock));
                }
                else
                {
                    if (emballage != null && emballage.EmballageGros == item.Emballage)
                    {
                        query.Quantite += item.Quantite * article.QuantiteDetail;
                    }
                    else
                    {
                        query.Quantite += item.Quantite;
                    }
                    query.Quantite += item.Quantite;
                    await _stockRepository.UpdateAsync(_mapper.Map<Stock>(query));

                }


                await _mouvementRepository.AddAsync(_mapper.Map<Mouvement>(mouvement));
            }

            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Achat>> Update(Guid id, [FromBody] AchatModel request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.DateAchat = request.DateAchat;
            query.NumeroFacture = request.NumeroFacture;
            query.NumeroAchat = request.NumeroAchat;
            query.FournisseurId = request.FournisseurId;
            query.LocationId = request.LocationId;
            query.MonnaieId = request.MonnaieId;
            query.MontantTotal = request.MontantTotal;
            query.TauxAchat = request.TauxAchat;
            query.DetailAchats = request.DetailAchats;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Achat>> FindAll()
        {
            var items = await (from a in _myDbContext.achats.Include(d => d.DetailAchats)
                               join f in _myDbContext.fournisseurs on a.FournisseurId equals f.Id
                               join m in _myDbContext.monnaies on a.MonnaieId equals m.Id
                               join l in _myDbContext.locations on a.LocationId equals l.Id

                               select new AchatList()
                               {


                                   Id = a.Id,

                                   DateAchat = a.DateAchat,

                                   NumeroFacture = a.NumeroFacture,

                                   MonnaieId = a.MonnaieId,

                                   Monnaie = m.Devise,

                                   LocationId = a.LocationId,

                                   Location = l.Designation,

                                   FournisseurId = a.FournisseurId,

                                   Fournisseur = f.Nom,

                                   TauxAchat = a.TauxAchat,

                                   MontantTotal = a.MontantTotal,

                                   NumeroAchat = a.NumeroAchat,

                                   DetailAchats = a.DetailAchats
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

