using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class HistoriquePrixVenteRepo : IHistoriquePrixVente
    {
        private readonly MyDbContext _myDbContext;

        public HistoriquePrixVenteRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<HistoriquePrixVente> AddAsync(HistoriquePrixVente entity)
        {
            var result = _myDbContext.historiquePrixVentes.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.historiquePrixVentes.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.historiquePrixVentes.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<HistoriquePrixVente>> FindAllAsync()
        {
            var result = await _myDbContext.historiquePrixVentes.ToListAsync();
            return result;
        }

        public async Task<HistoriquePrixVente> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.historiquePrixVentes.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<HistoriquePrixVente> UpdateAsync(HistoriquePrixVente entity)
        {
            _myDbContext.historiquePrixVentes.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
