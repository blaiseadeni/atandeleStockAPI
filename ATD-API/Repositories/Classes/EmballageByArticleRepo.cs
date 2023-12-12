using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class EmballageByArticleRepo : IEmballageByArticle
    {
        private readonly MyDbContext _myDbContext;

        public EmballageByArticleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<EmballageByArticle> AddAsync(EmballageByArticle entity)
        {
            var result = _myDbContext.emballageByArticles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.emballageByArticles.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.emballageByArticles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<EmballageByArticle>> FindAllAsync()
        {
            var result = await _myDbContext.emballageByArticles.ToListAsync();
            return result;
        }

        public async Task<EmballageByArticle> FindByIdAsync(Guid id)
        {

            var result = await _myDbContext.emballageByArticles.FirstOrDefaultAsync(c => c.ArticleId == id);

            return result;
        }

        public async Task<EmballageByArticle> UpdateAsync(EmballageByArticle entity)
        {
            _myDbContext.emballageByArticles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
