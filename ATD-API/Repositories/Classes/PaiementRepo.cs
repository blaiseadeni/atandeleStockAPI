using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class PaiementRepo : IPaiement
    {
        private readonly MyDbContext _myDbContext;

        public PaiementRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Paiement> AddAsync(Paiement entity)
        {
            var result = _myDbContext.paiements.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.paiements.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.paiements.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Paiement>> FindAllAsync()
        {
            var result = await _myDbContext.paiements.ToListAsync();
            return result;

        }

        public async Task<Paiement> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.paiements.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Paiement> UpdateAsync(Paiement entity)
        {
            _myDbContext.paiements.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
