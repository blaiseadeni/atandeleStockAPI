using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class SignaletiqueRepo : ISignaletique
    {
        private readonly MyDbContext _myDbContext;

        public SignaletiqueRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Signaletique> AddAsync(Signaletique entity)
        {
            var result = _myDbContext.signaletiques.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.signaletiques.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.signaletiques.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Signaletique>> FindAllAsync()
        {
            var result = await _myDbContext.signaletiques.ToListAsync();
            return result;
        }

        public async Task<Signaletique> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.signaletiques.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Signaletique> UpdateAsync(Signaletique entity)
        {
            _myDbContext.signaletiques.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
