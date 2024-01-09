using ATD_API.Data;
using ATD_API.Dtos;
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
    public class LocationController : ControllerBase
    {
        private readonly ILocation _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public LocationController(ILocation repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Add([FromBody] LocationMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Location>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> Update(Guid id, [FromBody] LocationMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.designation = request.designation;
            query.dateCreation = request.dateCreation;
            // query.DateCloture = request.DateCloture;
            query.numeroFacture = request.numeroFacture;
            query.numeroLivraison = request.numeroLivraison;
            query.addresse = request.addresse;
            query.numeroAchat = request.numeroAchat;
            query.flag = request.flag;
            query.numeroCommande = request.numeroCommande;
            query.societeId = request.societeId;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Location>> FindAll()
        {
            var items = await (from l in _myDbContext.locations
                               join s in _myDbContext.parametreSocietes on l.societeId equals s.id
                               select new LocationList()
                               {

                                   id = l.id,
                                   designation = l.designation,
                                   dateCreation = l.dateCreation,
                                   societe = s.denomination,
                                   dateCloture = l.dateCloture,
                                   flag = l.flag,
                                   addresse = l.addresse,
                                   numeroAchat = l.numeroAchat,
                                   numeroCommande = l.numeroCommande,
                                   numeroFacture = l.numeroFacture,
                                   numeroLivraison = l.numeroLivraison

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
