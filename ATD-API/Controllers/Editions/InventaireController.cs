using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Editions
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventaireController : ControllerBase
    {
        private readonly IInventaire _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public InventaireController(IInventaire repository, IMapper mapper, MyDbContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Inventaire>> Add([FromBody] InventaireMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Inventaire>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Inventaire>> Update(Guid id, [FromBody] InventaireMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.ecart = request.ecart;
            query.quantiteLogique = request.quantiteLogique;
            query.quantitePhysique = request.quantitePhysique;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Inventaire>> FindAll()
        {
            var items = await (from x in _dbContext.inventaires
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               join a in _dbContext.articles on x.articleId equals a.id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = u.nom + " " + u.postnom,
                                   ecart = x.ecart,
                                   date = x.date,
                                   articleId = a.designation,
                                   quantitePhysique = x.quantitePhysique,
                                   quantiteLogique = x.quantiteLogique

                               }).ToListAsync();
            //var items = await _repository.FindAllAsync();
            return Ok(items);
        }

        [HttpPost("inventaire")]
        public async Task<ActionResult> FindInvent(InvetaireQuery query)
        {
            var invent = _dbContext.article_stocks
                 .Where(c => c.articleId == query.articleId && c.locationId == query.locationId)
                                  .FirstOrDefault();
            return Ok(invent);

            //var invent = _dbContext.mouvementStocks
            //     .Where(c => c.articleId == query.articleId && c.locationId == query.locationId)
            //     .OrderByDescending(x => x.date)
            //     .Take(1)
            //     .OrderBy(x => x.date)
            //     .FirstOrDefault();
            //return Ok(invent);
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
