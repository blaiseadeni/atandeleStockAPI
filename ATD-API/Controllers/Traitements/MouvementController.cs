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

        [HttpGet]
        public async Task<ActionResult<Mouvement>> FindAll()
        {
            var items = await (from m in _myDbContext.mouvements
                               join l in _myDbContext.locations on m.LocationId equals l.Id

                               select new MouvementList()
                               {

                                   Id = m.Id,
                                   Type = m.Type,
                                   Designation = m.Designation,
                                   ArticleId = m.ArticleId,
                                   Article = m.Article,
                                   LocationId = m.LocationId,
                                   Location = l.Designation,
                                   Quantite = m.Quantite,
                                   Created = m.Created,
                                   Emballage = m.Emballage

                               }).ToListAsync();
            return Ok(items);
        }
    }
}
