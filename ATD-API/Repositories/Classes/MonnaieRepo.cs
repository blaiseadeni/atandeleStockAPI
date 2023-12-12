using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class MonnaieRepo : IMonnaie
    {
        private readonly MyDbContext _myDbContext;

        public MonnaieRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Monnaie> AddAsync(Monnaie entity)
        {
            var result = _myDbContext.monnaies.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.monnaies.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.monnaies.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Monnaie>> FindAllAsync()
        {
            var result = await _myDbContext.monnaies.ToListAsync();
            return result;
        }

        public async Task<Monnaie> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.monnaies.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Monnaie> UpdateAsync(Monnaie entity)
        {
            _myDbContext.monnaies.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
