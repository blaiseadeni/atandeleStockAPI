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

            if (result != null)
            {
                var query = await _repositoryFacture.FindByIdAsync(result.factureId);
                query.resteApayer -= result.montantPayer;
                query.montantPayer += result.montantPayer;
                if (query.resteApayer == 0)
                {
                    query.status = "PAYER";
                }
                else
                {
                    query.status = "NON PAYER";
                }

                await _repositoryFacture.UpdateAsync(query);
            }

            return Ok(result.id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Paiement>> Update(Guid id, [FromBody] PaiementMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.montantPayer = request.montantPayer;
            query.datePaiement = request.datePaiement;
            query.utilisateurId = request.utilisateurId;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Paiement>> FindAll(Guid id)
        {
            var items = await (from p in _myDbContext.paiements
                               join f in _myDbContext.factures on p.factureId equals f.id
                               join u in _myDbContext.utilisateurs on p.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = p.id,
                                   factureId = p.factureId,
                                   numeroFacture = f.numeroFacture,
                                   datePaiement = p.datePaiement,
                                   montantPayer = p.montantPayer,
                                   utilisateurId = p.utilisateurId,
                                   utilisateur = u.nom + " " + u.postnom
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

