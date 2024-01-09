using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class FactureRepo : IFacture
    {
        private readonly MyDbContext _myDbContext;

        public FactureRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Facture> AddAsync(Facture entity)
        {
            var result = _myDbContext.factures.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.factures.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.factures.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Facture>> FindAllAsync()
        {
            var result = await _myDbContext.factures.Include(d => d.detailFactures).ToListAsync();
            return result;

        }

        public async Task<Facture> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.factures.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Facture> UpdateAsync(Facture entity)
        {
            _myDbContext.factures.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
