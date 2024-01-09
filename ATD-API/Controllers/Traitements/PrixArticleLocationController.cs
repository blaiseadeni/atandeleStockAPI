using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Traitements
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixArticleLocationController : ControllerBase
    {
        private readonly IPrixArticleLocation _repository;
        private readonly IHistoriquePrixVente _repositoryHisto;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;


        public PrixArticleLocationController(IPrixArticleLocation repository, IMapper mapper, MyDbContext myDbContext, IHistoriquePrixVente repositoryHisto)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
            _repositoryHisto = repositoryHisto;
        }

        [HttpPost]
        public async Task<ActionResult<PrixArticleLocation>> Add([FromBody] PrixArticleLocationMod request)
        {
            var quer = await _myDbContext.prixArticleLocations.FirstOrDefaultAsync(x => x.articleId == request.articleId && x.locationId == request.locationId);
            if (quer == null)
            {
                var result = await _repository.AddAsync(_mapper.Map<PrixArticleLocation>(request));
            }
            else
            {
                var query = await _myDbContext.prixArticleLocations.FirstOrDefaultAsync(x => x.articleId == request.articleId && x.locationId == request.locationId);
                query.locationId = request.locationId;
                query.articleId = request.articleId;
                query.prixVenteGros = request.prixVenteGros;
                query.prixVenteDetail = request.prixVenteDetail;
                query.utilisateurId = request.utilisateurId;
                query.created = request.created;
                var result = await _repository.UpdateAsync(query);

                HistoriquePrixVenteMod model = new HistoriquePrixVenteMod();

                var res = await _myDbContext.prixArticleLocations.FirstOrDefaultAsync(x => x.articleId == request.articleId && x.locationId == request.locationId);

                model.utilisateurId = request.utilisateurId;
                model.articleId = request.articleId;
                model.locationId = query.locationId;
                model.dateModification = request.created;
                model.ancienPrixDeVenteDetail = res.prixVenteDetail;
                model.ancienPrixDeVenteGros = res.prixVenteGros;
                model.nouveauPrixDeVenteDetail = request.prixVenteDetail;
                model.nouveauPrixDeVenteGros = request.prixVenteGros;

                var modif = await _repositoryHisto.AddAsync(_mapper.Map<HistoriquePrixVente>(model));
            }
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrixArticleLocation>> Update(Guid id, [FromBody] PrixArticleLocationMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.locationId = request.locationId;
            query.articleId = request.articleId;
            query.prixVenteGros = request.prixVenteGros;
            query.prixVenteDetail = request.prixVenteDetail;
            query.utilisateurId = request.utilisateurId;
            query.created = request.created;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<PrixArticleLocationMod>> FindAll(Guid id)
        {
            var items = await (from p in _myDbContext.prixArticleLocations
                               join l in _myDbContext.locations on p.locationId equals l.id
                               join a in _myDbContext.articles on p.articleId equals a.id
                               join u in _myDbContext.utilisateurs on p.utilisateurId equals u.id
                               join lo in _myDbContext.locations on u.locationId equals id
                               select new
                               {

                                   id = p.id,
                                   articleId = p.articleId,
                                   article = a.designation,
                                   locationId = p.locationId,
                                   location = l.designation,
                                   prixVenteDetail = p.prixVenteDetail,
                                   prixVenteGros = p.prixVenteGros,
                                   created = p.created,
                                   utilisateuId = p.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom

                               }).ToListAsync();
            return Ok(items.Distinct());
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
