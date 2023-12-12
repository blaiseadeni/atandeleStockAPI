using ATD_API.Data;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATD_API.Controllers.Traitements
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaieFactureController : ControllerBase
    {
        private readonly IFacture _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public PaieFactureController(IFacture repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpGet("{numero}")]
        public async Task<ActionResult> Find(string numero)
        {
            var result = _myDbContext.factures.FirstOrDefault(f => f.NumeroFacture.Equals(numero));
            return Ok(result);
        }

    }
}
