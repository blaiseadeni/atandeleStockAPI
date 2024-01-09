using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametreSocieteController : ControllerBase
    {
        private readonly IParametreSociete _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public ParametreSocieteController(IParametreSociete repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<ParametreSociete>> Add([FromBody] ParametreSocieteMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<ParametreSociete>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParametreSociete>> Update(Guid id, [FromBody] ParametreSocieteMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.idNat = request.idNat;
            query.addresse = request.addresse;
            query.telephone = request.telephone;
            query.attachement = request.attachement;
            query.rccm = request.rccm;
            query.tva = request.tva;
            query.denomination = request.denomination;
            query.monnaie = request.monnaie;
            query.ville = request.ville;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<ParametreSociete>> FindAll()
        {
            var items = await (from p in _myDbContext.parametreSocietes
                               join u in _myDbContext.utilisateurs on p.utilisateurId equals u.id

                               select new
                               {
                                   id = p.id,
                                   created = p.created,
                                   denomination = p.denomination,
                                   telephone = p.telephone,
                                   addresse = p.addresse,
                                   ville = p.ville,
                                   idNat = p.idNat,
                                   rccm = p.rccm,
                                   tva = p.tva,
                                   monnaie = p.monnaie,
                                   attachement = p.attachement,
                                   utilisateurId = p.utilisateurId,
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
