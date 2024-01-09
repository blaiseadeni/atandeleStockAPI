using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class PrixAchatArticleRepo : IPrixAchatArticle
    {
        private readonly MyDbContext _myDbContext;

        public PrixAchatArticleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<PrixAchatArticle> AddAsync(PrixAchatArticle entity)
        {
            var result = _myDbContext.prixAchatArticles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.prixAchatArticles.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.prixAchatArticles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<PrixAchatArticle>> FindAllAsync()
        {
            var result = await _myDbContext.prixAchatArticles.ToListAsync();
            return result;
        }

        public async Task<PrixAchatArticle> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.prixAchatArticles.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<PrixAchatArticle> UpdateAsync(PrixAchatArticle entity)
        {
            _myDbContext.prixAchatArticles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
