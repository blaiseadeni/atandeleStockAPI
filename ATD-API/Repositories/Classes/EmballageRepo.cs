using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class EmballageRepo : IEmballage
    {
        private readonly MyDbContext _myDbContext;

        public EmballageRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Emballage> AddAsync(Emballage entity)
        {
            var result = _myDbContext.emballages.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.emballages.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.emballages.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Emballage>> FindAllAsync()
        {
            var result = await _myDbContext.emballages.ToListAsync();
            return result;
        }

        public async Task<Emballage> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.emballages.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Emballage> UpdateAsync(Emballage entity)
        {
            _myDbContext.emballages.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
