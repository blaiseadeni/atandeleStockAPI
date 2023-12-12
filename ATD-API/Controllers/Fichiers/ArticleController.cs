using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Controllers.Fichiers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticle _repository;
        private readonly IMapper _mapper;
        private readonly MyDbContext _myDbContext;

        public ArticleController(IArticle repository, IMapper mapper, MyDbContext myDbContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDbContext = myDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Add([FromBody] ArticleMod request)
        {
            var result = await _repository.AddAsync(_mapper.Map<Article>(request));
            EmballageByArticle emballage = new EmballageByArticle();
            var emballageGros = _myDbContext.emballages.Where(x => x.Id.Equals(request.EmballageGrosId)).FirstOrDefault();
            var emballageDetail = _myDbContext.emballages.Where(x => x.Id.Equals(request.EmballageDetailId)).FirstOrDefault();
            emballage.ArticleId = result.Id;
            emballage.EmballageGros = emballageGros.Libelle;
            emballage.EmballageDetail = emballageDetail.Libelle;
            _myDbContext.emballageByArticles.Add(emballage);
            _myDbContext.SaveChangesAsync();
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Update(Guid id, [FromBody] ArticleMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.FamilleId = request.FamilleId;
            query.EmballageDetailId = request.EmballageDetailId;
            query.EmballageGrosId = request.EmballageGrosId;
            query.Designation = request.Designation;
            query.StockMinimal = request.StockMinimal;
            query.QuantiteDetail = request.QuantiteDetail;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Article>> FindAll()
        {
            var items = await (from a in _myDbContext.articles
                               join f in _myDbContext.familles on a.FamilleId equals f.Id
                               join e in _myDbContext.emballageByArticles on a.Id equals e.ArticleId
                               select new ArticleList()
                               {
                                   Id = a.Id,
                                   Code = a.Code,
                                   Designation = a.Designation,
                                   Famille = f.Libelle,
                                   FamilleId = a.FamilleId,
                                   EmballageGros = e.EmballageGros,
                                   EmballageDetail = e.EmballageDetail,
                                   StockMinimal = a.StockMinimal,
                                   QuantiteDetail = a.QuantiteDetail,
                                   Created = a.Created

                               }).ToListAsync();
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
