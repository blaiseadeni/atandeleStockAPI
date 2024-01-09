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
    public class FournisseurController : ControllerBase
    {
        private readonly IFournisseur _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public FournisseurController(IFournisseur repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Fournisseur>> Add([FromBody] FournisseurMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Fournisseur>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Fournisseur>> Update(Guid id, [FromBody] FournisseurMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.adresse = request.adresse;
            query.telephone = request.telephone;
            query.nom = request.nom;
            query.ville = request.ville;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Fournisseur>> FindAll(Guid id)
        {
            var items = await (from x in _dbContext.fournisseurs
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               join l in _dbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = x.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   nom = x.nom,
                                   ville = x.ville,
                                   adresse = x.adresse,
                                   telephone = x.telephone,
                                   created = x.created,

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
