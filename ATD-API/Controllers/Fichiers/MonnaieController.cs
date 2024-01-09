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
    public class MonnaieController : ControllerBase
    {
        private readonly IMonnaie _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public MonnaieController(IMonnaie repository, IMapper mapper, MyDbContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Monnaie>> Add([FromBody] MonnaieMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Monnaie>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Monnaie>> Update(Guid id, [FromBody] MonnaieMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.libelle = request.libelle;
            query.devise = request.devise;
            query.estLocal = request.estLocal;
            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Monnaie>> FindAll()
        {

            var items = await (from x in _dbContext.monnaies
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = x.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   libelle = x.libelle,
                                   created = x.created,
                                   devise = x.devise,

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

