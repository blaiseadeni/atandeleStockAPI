using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class ArticleRepo : IArticle
    {
        private readonly MyDbContext _myDbContext;

        public ArticleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Article> AddAsync(Article entity)
        {
            var result = _myDbContext.articles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.articles.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.articles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Article>> FindAllAsync()
        {
            var result = await _myDbContext.articles.ToListAsync();
            return result;
        }

        public async Task<Article> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.articles.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Article> UpdateAsync(Article entity)
        {
            _myDbContext.articles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
