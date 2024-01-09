using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmballageController : ControllerBase
    {
        private readonly IEmballage _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public EmballageController(IEmballage repository, IMapper mapper, MyDbContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Emballage>> Add([FromBody] EmballageMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Emballage>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Emballage>> Update(Guid id, [FromBody] EmballageMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.libelle = request.libelle;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Emballage>> FindAll(Guid id)
        {
            // var items = await _repository.FindAllAsync();
            var items = await (from x in _dbContext.emballages
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               join l in _dbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = x.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   libelle = x.libelle,
                                   created = x.created

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
