using BC = BCrypt.Net.BCrypt;
using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Parametres
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateur _repository;
        private readonly ILogin _repositoryLogin;
        private readonly MyDbContext _myDbContext;
        private readonly IMapper _mapper;

        public UtilisateurController(IUtilisateur repository, IMapper mapper, ILogin repositoryLogin, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryLogin = repositoryLogin;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Utilisateur>> Add([FromBody] UtilisateurRequest request)
        {
            UtilisateurMod model = new UtilisateurMod();

            model.locationId = request.locationId;
            model.roleId = request.roleId;
            model.nom = request.nom;
            model.postnom = request.postnom;
            var result = await _repository.AddAsync(_mapper.Map<Utilisateur>(model));

            LoginMod login = new LoginMod();

            var password = "12345";
            login.utilisateur = request.utilisateur;
            login.state = false;
            login.pwd = BC.HashPassword(password);
            login.utilisateurId = result.id;
            var res = await _repositoryLogin.AddAsync(_mapper.Map<Login>(login));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Utilisateur>> Update(Guid id, [FromBody] UtilisateurRequest request)
        {
            Login login = new Login();
            var query = await _repository.FindByIdAsync(id);
            query.locationId = request.locationId;
            query.nom = request.nom;
            query.postnom = request.postnom;
            query.roleId = request.roleId;

            //login.Pwd = request.u


            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Utilisateur>> FindAll(Guid id)
        {
            //var items = await _repository.FindAllAsync();
            //return Ok(items);

            var items = await (from log in _myDbContext.logins
                               join u in _myDbContext.utilisateurs on log.utilisateurId equals u.id
                               join lo in _myDbContext.locations on u.locationId equals id
                               join s in _myDbContext.parametreSocietes on lo.societeId equals s.id
                               join r in _myDbContext.roles on u.roleId equals r.id
                               select new UserResponse()
                               {
                                   id = u.id,
                                   nom = u.nom,
                                   postnom = u.postnom,
                                   locationId = u.locationId,
                                   location = lo.designation,
                                   roleId = u.roleId,
                                   role = r.libelle,
                                   loginId = log.id,
                                   utilisateur = u.nom,
                                   state = log.state,
                                   created = u.created
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

