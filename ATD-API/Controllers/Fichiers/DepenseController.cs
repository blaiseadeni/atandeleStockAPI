using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepenseController : ControllerBase
    {
        private readonly IDepense _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public DepenseController(IDepense repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Depense>> Add([FromBody] DepenseMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Depense>(request));
            return Ok("Saved successfullly");
        }

        [HttpPost("verify")]
        public async Task<ActionResult> Verify(VerifyRequest request)
        {
            var items = (from x in _myDbContext.depenses
                         join u in _myDbContext.utilisateurs on x.utilisateurId equals u.id
                         join l in _myDbContext.locations on u.locationId equals l.id
                         where l.id == request.locationId
                         select new
                         {
                             id = x.id,
                             utilisateur = u.nom + " " + u.postnom,
                             utilisateurId = x.utilisateurId,
                             motif = x.motif,
                             montant = x.montant,
                             beneficiaire = x.beneficiaire,
                             created = x.created

                         })
                            .Where(c => (c.created >= DateTime.Parse(request.date1) && c.created <= DateTime.Parse(request.date2)))
                .GroupBy(x => x.created)
                .Select(group => new
                {
                    Created = group.Key,
                    montant = group.Sum(c => c.montant),
                })
                .OrderBy(dc => dc.montant)
                .ToList();

            montantDto montant = new montantDto();
            foreach (var item in items)
            {
                montant.montant += item.montant;
            }

            return Ok(montant);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Depense>> Update(Guid id, [FromBody] DepenseMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.montant = request.montant;
            query.beneficiaire = request.beneficiaire;
            query.motif = request.motif;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Depense>> FindAll(Guid id)
        {
            var items = await (from x in _myDbContext.depenses
                               join u in _myDbContext.utilisateurs on x.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = x.id,
                                   utilisateur = u.nom + " " + u.postnom,
                                   utilisateurId = x.utilisateurId,
                                   motif = x.motif,
                                   montant = x.montant,
                                   beneficiaire = x.beneficiaire,
                                   created = x.created
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
