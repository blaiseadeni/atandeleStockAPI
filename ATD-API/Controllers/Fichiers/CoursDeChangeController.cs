using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursDeChangeController : ControllerBase
    {
        private readonly ICoursDeChange _repository;
        private readonly IMapper _mapper;

        public CoursDeChangeController(ICoursDeChange repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CoursDeChange>> Add([FromBody] CoursDeChangeMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<CoursDeChange>(request));
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CoursDeChange>> Update(Guid id, [FromBody] CoursDeChangeMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.DateEnCours = request.DateEnCours;
            query.TauxVente = request.TauxVente;
            query.Monnaie = request.Monnaie;
            query.TauxVente = request.TauxVente;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<CoursDeChange>> FindAll()
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
