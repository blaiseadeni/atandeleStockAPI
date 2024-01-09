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
    public class CoursDeChangeController : ControllerBase
    {
        private readonly ICoursDeChange _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public CoursDeChangeController(ICoursDeChange repository, IMapper mapper, MyDbContext dbcontext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbcontext;
        }

        [HttpPost]
        public async Task<ActionResult<CoursDeChange>> Add([FromBody] CoursDeChangeMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<CoursDeChange>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CoursDeChange>> Update(Guid id, [FromBody] CoursDeChangeMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.dateEnCours = request.dateEnCours;
            query.tauxVente = request.tauxVente;
            query.monnaie = request.monnaie;
            query.tauxVente = request.tauxVente;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<CoursDeChange>> FindAll()
        {
            var items = await (from x in _dbContext.coursDeChanges
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = x.utilisateurId,
                                   dateEnCours = x.dateEnCours,
                                   tauxAchat = x.tauxAchat,
                                   tauxVente = x.tauxVente,
                                   monnaie = x.monnaie,
                                   utilisateur = u.nom + " " + u.postnom

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
