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
            Random random = new Random();
            int num = random.Next();
            request.numeroCommande = DateTime.Now.Year.ToString() + DateTime.Now.Month + num;
            //request.concerne = "rupture de stock";
            request.tauxDeChange = 1;

            var result = await _repository.AddAsync(_mapper.Map<Commande>(request));
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Commande>> Update(Guid id, [FromBody] CommandeMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            //query.concerne = request.concerne;
            //query.observation = request.observation;
            query.fournisseurId = request.fournisseurId;
            query.numeroCommande = request.numeroCommande;
            query.dateCommande = request.dateCommande;
            query.dateLivraison = request.dateLivraison;
            //query.echeance = request.echeance;
            query.fournisseurId = request.fournisseurId;
            ////query.tauxDeChange = request.tauxDeChange;
            query.status = request.status;
            query.totalCommande = request.totalCommande;
            query.detailCommandes = request.detailCommandes;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Commande>> FindAll(Guid id)
        {
            var items = await (from c in _myDbContext.commandes.Include(d => d.detailCommandes)
                               join f in _myDbContext.fournisseurs on c.fournisseurId equals f.id
                               join u in _myDbContext.utilisateurs on c.utilisateurId equals u.id
                               join l in _myDbContext.locations on u.locationId equals id
                               select new
                               {
                                   id = c.id,
                                   numeroCommande = c.numeroCommande,
                                   dateCommande = c.dateCommande,
                                   dateLivraison = c.dateLivraison,
                                   //echeance = c.echeance,
                                   fournisseurId = c.fournisseurId,
                                   fournisseur = f.nom,
                                   //observation = c.observation,
                                   //concerne = c.concerne,
                                   totalCommande = c.totalCommande,
                                   tauxDeChange = c.tauxDeChange,
                                   status = c.status,
                                   utilisateur = u.nom + " " + u.postnom,
                                   utilisateurId = c.utilisateurId,
                                   detailCommandes = c.detailCommandes,


                               }).ToListAsync();
            return Ok(items.DistinctBy(c => c.id));
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

