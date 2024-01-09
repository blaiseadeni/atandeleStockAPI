using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Models;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Parametres
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public RoleController(IRole repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Add([FromBody] RoleMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Role>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> Update(Guid id, [FromBody] RoleMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.libelle = request.libelle;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Role>> FindAll(Guid id)
        {
            // var items = await _repository.FindAllAsync();
            var items = await (from r in _myDbContext.roles
                               join lo in _myDbContext.locations on r.locationId equals id
                               select new
                               {
                                   id = r.id,
                                   libelle = r.libelle
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
