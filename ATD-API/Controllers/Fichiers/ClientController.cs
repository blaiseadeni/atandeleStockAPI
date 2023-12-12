using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ISignaletique _repository;
        private readonly IMapper _mapper;

        public ClientController(ISignaletique repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Signaletique>> Add([FromBody] SignaletiqueMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Signaletique>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Signaletique>> Update(Guid id, [FromBody] SignaletiqueMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.Nom = request.Nom;
            query.Telephone = request.Telephone;
            query.Addresse = request.Addresse;
            query.Categorie = request.Categorie;
            query.Email = request.Email;
            query.RaisonSociale = request.RaisonSociale;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Signaletique>> FindAll()
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
