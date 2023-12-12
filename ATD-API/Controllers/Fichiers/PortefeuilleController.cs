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
    public class PortefeuilleController : ControllerBase
    {
        private readonly IPortefeuille _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public PortefeuilleController(IPortefeuille repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Portefeuille>> Add([FromBody] PortefeuilleMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Portefeuille>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Portefeuille>> Update(Guid id, [FromBody] PortefeuilleMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.clientId = request.clientId;
            query.montant = request.montant;


            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Portefeuille>> FindAll()
        {
            var items = await (from p in _myDbContext.portefeuilles
                               join s in _myDbContext.signaletiques on p.clientId equals s.Id
                               join m in _myDbContext.monnaies on p.monnaieId equals m.Id
                               select new PortefeuilleList()
                               {
                                   Id = p.Id,
                                   clientId = p.clientId,
                                   client = s.Nom,
                                   monnaieId = p.monnaieId,
                                   monnaie = m.Devise,
                                   montant = p.montant,
                                   created = p.created

                               }).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            //  var result = await _repository.FindByIdAsync(id);
            //  return Ok(result);
            var items = await (from p in _myDbContext.portefeuilles
                               join s in _myDbContext.signaletiques on p.clientId equals s.Id
                               join m in _myDbContext.monnaies on p.monnaieId equals m.Id
                               where p.clientId == id
                               select new PortefeuilleList()
                               {
                                   Id = p.Id,
                                   clientId = p.clientId,
                                   client = s.Nom,
                                   monnaieId = p.monnaieId,
                                   monnaie = m.Devise,
                                   montant = p.montant,
                                   created = p.created

                               }).FirstOrDefaultAsync();
            return Ok(items);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            return Ok("Deleted successfully");
        }
    }
}
