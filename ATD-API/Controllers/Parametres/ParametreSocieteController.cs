using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametreSocieteController : ControllerBase
    {
        private readonly IParametreSociete _repository;
        private readonly IMapper _mapper;

        public ParametreSocieteController(IParametreSociete repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ParametreSociete>> Add([FromBody] ParametreSocieteMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<ParametreSociete>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParametreSociete>> Update(Guid id, [FromBody] ParametreSocieteMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.IdNat = request.IdNat;
            query.Addresse = request.Addresse;
            query.Telephone = request.Telephone;
            query.Attachement = request.Attachement;
            query.Rccm = request.Rccm;
            query.Tva = request.Tva;
            query.Denomination = request.Denomination;
            query.Monnaie = request.Monnaie;
            query.Ville = request.Ville;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<ParametreSociete>> FindAll()
        {
            var items = await _repository.FindAllAsync();
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
