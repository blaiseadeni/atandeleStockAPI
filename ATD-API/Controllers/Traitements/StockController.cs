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

        [HttpGet("all/{id:Guid}")]
        public async Task<ActionResult<Stock>> FindAll(Guid id)
        {
            var items = await (from s in _myDbContext.article_stocks
                               join l in _myDbContext.locations on s.locationId equals id
                               join a in _myDbContext.articles on s.articleId equals a.id
                               select new StockList()
                               {

                                   id = s.id,
                                   articleId = s.articleId,
                                   article = a.designation,
                                   locationId = s.locationId,
                                   location = l.designation,
                                   quantite = s.quantite,
                                   seuil = a.stockMinimal

                               }).ToListAsync();
            return Ok(items.DistinctBy(s => s.id));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> Find(Guid id)
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }
    }
}
