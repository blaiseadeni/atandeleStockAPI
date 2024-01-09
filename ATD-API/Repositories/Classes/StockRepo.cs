using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class StockRepo : IStock
    {
        private readonly MyDbContext _myDbContext;

        public StockRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Stock> AddAsync(Stock entity)
        {
            var result = _myDbContext.article_stocks.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.article_stocks.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.article_stocks.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Stock>> FindAllAsync()
        {
            var result = await _myDbContext.article_stocks.ToListAsync();
            return result;
        }

        public async Task<Stock> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.article_stocks.FirstOrDefaultAsync(c => c.articleId == id);
            return result;
        }

        public async Task<Stock> UpdateAsync(Stock entity)
        {
            _myDbContext.article_stocks.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
