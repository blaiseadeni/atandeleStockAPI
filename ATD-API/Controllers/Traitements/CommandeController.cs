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
    public class CommandeController : ControllerBase
    {
        private readonly ICommande _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public CommandeController(ICommande repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Commande>> Add([FromBody] CommandeMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Commande>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Commande>> Update(Guid id, [FromBody] CommandeMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.Concerne = request.Concerne;
            query.Observation = request.Observation;
            query.FournisseurId = request.FournisseurId;
            query.NumeroCommande = request.NumeroCommande;
            query.DateCommande = request.DateCommande;
            query.DateLivraison = request.DateLivraison;
            query.Echeance = request.Echeance;
            query.FournisseurId = request.FournisseurId;
            query.TauxDeChange = request.TauxDeChange;
            query.MonnaieId = request.MonnaieId;
            query.Status = request.Status;
            query.TotalCommande = request.TotalCommande;
            query.DetailCommandes = request.DetailCommandes;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Commande>> FindAll()
        {
            var items = await (from c in _myDbContext.commandes.Include(d => d.DetailCommandes)
                               join f in _myDbContext.fournisseurs on c.FournisseurId equals f.Id
                               join m in _myDbContext.monnaies on c.MonnaieId equals m.Id

                               select new CommandeList()
                               {
                                   Id = c.Id,

                                   NumeroCommande = c.NumeroCommande,

                                   DateCommande = c.DateCommande,

                                   DateLivraison = c.DateLivraison,

                                   Echeance = c.Echeance,

                                   FournisseurId = c.FournisseurId,

                                   Fournisseur = f.Nom,

                                   Observation = c.Observation,

                                   Concerne = c.Concerne,

                                   TotalCommande = c.TotalCommande,

                                   MonnaieId = c.MonnaieId,

                                   Monnaie = m.Libelle,

                                   TauxDeChange = c.TauxDeChange,

                                   Status = c.Status,

                                   DetailCommandes = c.DetailCommandes,


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

