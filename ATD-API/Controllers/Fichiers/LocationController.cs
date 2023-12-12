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
            query.Designation = request.Designation;
            query.DateCreation = request.DateCreation;
            // query.DateCloture = request.DateCloture;
            query.NumeroFacture = request.NumeroFacture;
            query.NumeroLivraison = request.NumeroLivraison;
            query.Addresse = request.Addresse;
            query.NumeroAchat = request.NumeroAchat;
            query.Flag = request.Flag;
            query.NumeroCommande = request.NumeroCommande;
            query.SocieteId = request.SocieteId;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Location>> FindAll()
        {
            var items = await (from l in _myDbContext.locations
                               join s in _myDbContext.parametreSocietes on l.SocieteId equals s.Id
                               select new LocationList()
                               {

                                   Id = l.Id,
                                   Designation = l.Designation,
                                   DateCreation = l.DateCreation,
                                   Societe = s.Denomination,
                                   DateCloture = l.DateCloture,
                                   Flag = l.Flag,
                                   Addresse = l.Addresse,
                                   NumeroAchat = l.NumeroAchat,
                                   NumeroCommande = l.NumeroCommande,
                                   NumeroFacture = l.NumeroFacture,
                                   NumeroLivraison = l.NumeroLivraison

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
