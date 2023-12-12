using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Traitements
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly IPaiement _repository;
        private readonly IFacture _repositoryFacture;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;
        public PaiementController(IPaiement repository, IMapper mapper, MyDbContext myDbContext, IFacture repositoryFacture)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
            _repositoryFacture = repositoryFacture;
        }

        [HttpPost]
        public async Task<ActionResult<Paiement>> Add([FromBody] PaiementMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Paiement>(request));
            var query = await _repositoryFacture.FindByIdAsync(result.FactureId);
            if (query != null)
            {
                query.ResteApayer -= result.MontantPayer;
                query.MontantPayer += result.MontantPayer;
            }
            await _repositoryFacture.UpdateAsync(query);
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Paiement>> Update(Guid id, [FromBody] PaiementMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.MontantPayer = request.MontantPayer;
            query.DatePaiement = request.DatePaiement;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Paiement>> FindAll()
        {
            var items = await (from p in _myDbContext.paiements
                               join f in _myDbContext.factures on p.FactureId equals f.Id


                               select new PaiementList()
                               {
                                   FactureId = p.FactureId,
                                   numeroFacture = f.NumeroFacture,
                                   DatePaiement = p.DatePaiement,
                                   MontantPayer = p.MontantPayer

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

