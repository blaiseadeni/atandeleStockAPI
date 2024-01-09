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
            if (result != null)
            {
                EmballageByArticle emballage = new EmballageByArticle();
                var emballageGros = _myDbContext.emballages.Where(x => x.id.Equals(result.emballageGrosId)).FirstOrDefault();
                var emballageDetail = _myDbContext.emballages.Where(x => x.id.Equals(result.emballageDetailId)).FirstOrDefault();
                emballage.articleId = result.id;
                emballage.emballageGros = emballageGros.libelle;
                emballage.emballageDetail = emballageDetail.libelle;
                _myDbContext.emballageByArticles.Add(emballage);
                await _myDbContext.SaveChangesAsync();
            }
            return Ok("Saved successfullly");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Update(Guid id, [FromBody] ArticleMod request)
        {
            var query = await _repository.FindByIdAsync(id);
            query.familleId = request.familleId;
            query.emballageDetailId = request.emballageDetailId;
            query.emballageGrosId = request.emballageGrosId;
            query.designation = request.designation;
            query.stockMinimal = request.stockMinimal;
            query.quantiteDetail = request.quantiteDetail;

            var result = await _repository.UpdateAsync(query);
            return Ok("Updated successfully");
        }

        [HttpGet("all")]
        public async Task<ActionResult<Article>> FindAll()
        {
            var items = await (from a in _myDbContext.articles
                               join f in _myDbContext.familles on a.familleId equals f.id
                               join e in _myDbContext.emballageByArticles on a.id equals e.articleId
                               join u in _myDbContext.utilisateurs on a.utilisateurId equals u.id
                               select new
                               {
                                   id = a.id,
                                   code = a.code,
                                   designation = a.designation,
                                   famille = f.libelle,
                                   familleId = a.familleId,
                                   emballageGros = e.emballageGros,
                                   emballageDetail = e.emballageDetail,
                                   stockMinimal = a.stockMinimal,
                                   quantiteDetail = a.quantiteDetail,
                                   created = a.created,
                                   utilisateur = u.nom + " " + u.postnom,
                                   utilisateurId = a.utilisateurId
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
