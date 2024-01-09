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
    public class MouvementController : ControllerBase
    {
        private readonly IMouvement _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;
        public MouvementController(IMouvement repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }


        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Mouvement>> FindAll(Guid id)
        {
            var items = await (from m in _myDbContext.mouvementStocks
                               join l in _myDbContext.locations on m.locationId equals id

                               select new
                               {
                                   id = m.id,
                                   articleId = m.articleId,
                                   locationId = m.locationId,
                                   periode = m.periode,
                                   article = m.article,
                                   libelle = m.libelle,
                                   date = m.date,
                                   qteEntr = m.qteEntr,
                                   puEntr = m.puEntr,
                                   ptEnt = m.ptEnt,
                                   qteSort = m.qteSort,
                                   puSort = m.puSort,
                                   ptSort = m.ptSort,
                                   qteSt = m.qteSt

                               }).ToListAsync();
            return Ok(items.DistinctBy(c => c.id));
        }
    }
}
