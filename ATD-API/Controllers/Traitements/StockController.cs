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
    public class StockController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        private readonly IStock _repository;

        public StockController(MyDbContext myDbContext, IStock repository)
        {
            _myDbContext = myDbContext;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Stock>> FindAll()
        {
            var items = await (from s in _myDbContext.article_stocks
                               join l in _myDbContext.locations on s.LocationId equals l.Id
                               join a in _myDbContext.articles on s.ArticleId equals a.Id

                               select new StockList()
                               {

                                   Id = s.Id,
                                   ArticleId = s.ArticleId,
                                   Article = a.Designation,
                                   LocationId = s.LocationId,
                                   Location = l.Designation,
                                   Quantite = s.Quantite,
                                   Seuil = a.StockMinimal

                               }).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }
    }
}
