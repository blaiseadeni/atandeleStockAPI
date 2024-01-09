using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ISignaletique _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _dbContext;

        public ClientController(ISignaletique repository, IMapper mapper, MyDbContext dbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Signaletique>> Add([FromBody] SignaletiqueMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Signaletique>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Signaletique>> Update(Guid id, [FromBody] SignaletiqueMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.nom = request.nom;
            query.telephone = request.telephone;
            query.addresse = request.addresse;
            query.categorie = request.categorie;
            //query.email = request.email;
            //query.raisonSociale = request.raisonSociale;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Signaletique>> FindAll(Guid id)
        {
            var items = await (from x in _dbContext.signaletiques
                               join u in _dbContext.utilisateurs on x.utilisateurId equals u.id
                               join l in _dbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = x.id,
                                   utilisateurId = x.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom,
                                   nom = x.nom,
                                   telephone = x.telephone,
                                   created = x.created,
                                   categorie = x.categorie,
                                   addresse = x.addresse,
                                   //raisonSociale = x.raisonSociale,
                                   //email = x.email

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
