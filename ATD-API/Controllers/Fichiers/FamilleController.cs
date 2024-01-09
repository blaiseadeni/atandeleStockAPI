using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilleController : ControllerBase
    {
        private readonly IFamille _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public FamilleController(IFamille repository, IMapper mapper, MyDbContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Famille>> Add([FromBody] FamilleMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Famille>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Famille>> Update(Guid id, [FromBody] FamilleMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.libelle = request.libelle;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Famille>> FindAll(Guid id)
        {
            //var items = await _repository.FindAllAsync();
            var items = await (from f in _dbContext.familles
                               join u in _dbContext.utilisateurs on f.utilisateurId equals u.id
                               join l in _dbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = f.id,
                                   utilisateurId = f.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   libelle = f.libelle,
                                   created = f.created

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
