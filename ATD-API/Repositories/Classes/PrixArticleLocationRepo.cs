using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class PrixArticleLocationRepo : IPrixArticleLocation
    {
        private readonly MyDbContext _myDbContext;

        public PrixArticleLocationRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<PrixArticleLocation> AddAsync(PrixArticleLocation entity)
        {
            var result = _myDbContext.prixArticleLocations.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.prixArticleLocations.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.prixArticleLocations.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<PrixArticleLocation>> FindAllAsync()
        {
            var result = await _myDbContext.prixArticleLocations.ToListAsync();
            return result;
        }

        public async Task<PrixArticleLocation> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.prixArticleLocations.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<PrixArticleLocation> UpdateAsync(PrixArticleLocation entity)
        {
            _myDbContext.prixArticleLocations.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
