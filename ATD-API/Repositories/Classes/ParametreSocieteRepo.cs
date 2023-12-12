using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class ParametreSocieteRepo : IParametreSociete
    {
        private readonly MyDbContext _myDbContext;

        public ParametreSocieteRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<ParametreSociete> AddAsync(ParametreSociete entity)
        {
            var result = _myDbContext.parametreSocietes.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.parametreSocietes.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.parametreSocietes.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<ParametreSociete>> FindAllAsync()
        {
            var result = await _myDbContext.parametreSocietes.ToListAsync();
            return result;
        }

        public async Task<ParametreSociete> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.parametreSocietes.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<ParametreSociete> UpdateAsync(ParametreSociete entity)
        {
            _myDbContext.parametreSocietes.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
