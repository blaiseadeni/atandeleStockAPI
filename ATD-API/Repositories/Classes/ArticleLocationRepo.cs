using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class ArticleLocationRepo : IArticleLocation
    {

        private readonly MyDbContext _myDbContext;

        public ArticleLocationRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<ArticleLocation> AddAsync(ArticleLocation entity)
        {
            var result = _myDbContext.articleLocations.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.articleLocations.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.articleLocations.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<ArticleLocation>> FindAllAsync()
        {
            var result = await _myDbContext.articleLocations.ToListAsync();
            return result;
        }

        public async Task<ArticleLocation> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.articleLocations.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<ArticleLocation> UpdateAsync(ArticleLocation entity)
        {
            _myDbContext.articleLocations.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
