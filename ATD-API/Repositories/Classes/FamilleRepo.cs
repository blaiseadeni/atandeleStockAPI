using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class FamilleRepo : IFamille
    {
        private readonly MyDbContext _myDbContext;

        public FamilleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Famille> AddAsync(Famille entity)
        {
            var result = _myDbContext.familles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.familles.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.familles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Famille>> FindAllAsync()
        {
            var result = await _myDbContext.familles.ToListAsync();
            return result;
        }

        public async Task<Famille> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.familles.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Famille> UpdateAsync(Famille entity)
        {
            _myDbContext.familles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
