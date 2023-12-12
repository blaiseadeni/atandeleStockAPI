using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class DepenseRepo : IDepense
    {
        private readonly MyDbContext _myDbContext;


        public DepenseRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Depense> AddAsync(Depense entity)
        {
            var result = _myDbContext.depenses.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.depenses.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.depenses.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Depense>> FindAllAsync()
        {
            var result = await _myDbContext.depenses.ToListAsync();
            return result;
        }

        public async Task<Depense> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.depenses.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Depense> UpdateAsync(Depense entity)
        {
            _myDbContext.depenses.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
