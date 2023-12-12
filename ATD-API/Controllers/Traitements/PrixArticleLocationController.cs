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
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;


        public PrixArticleLocationController(IPrixArticleLocation repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<PrixArticleLocation>> Add([FromBody] PrixArticleLocationMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<PrixArticleLocation>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrixArticleLocation>> Update(Guid id, [FromBody] PrixArticleLocationMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.LocationId = request.LocationId;
            query.ArticleId = request.ArticleId;
            query.PrixVenteGros = request.PrixVenteGros;
            query.PrixVenteDetail = request.PrixVenteDetail;
            query.Monnaie = request.Monnaie;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<PrixArticleLocationMod>> FindAll()
        {
            var items = await (from p in _myDbContext.prixArticleLocations
                               join l in _myDbContext.locations on p.LocationId equals l.Id
                               join a in _myDbContext.articles on p.ArticleId equals a.Id

                               select new PrixArticleLocationList()
                               {

                                   Id = p.Id,

                                   ArticleId = p.ArticleId,

                                   Article = a.Designation,

                                   LocationId = p.LocationId,

                                   Location = l.Designation,

                                   PrixVenteDetail = p.PrixVenteDetail,

                                   PrixVenteGros = p.PrixVenteGros,

                                   Monnaie = p.Monnaie,





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
