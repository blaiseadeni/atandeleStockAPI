using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class PortefeuilleRepo : IPortefeuille
    {
        private readonly MyDbContext _myDbContext;

        public PortefeuilleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Portefeuille> AddAsync(Portefeuille entity)
        {
            var result = _myDbContext.portefeuilles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.portefeuilles.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.portefeuilles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Portefeuille>> FindAllAsync()
        {
            var result = await _myDbContext.portefeuilles.ToListAsync();
            return result;
        }

        public async Task<Portefeuille> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.portefeuilles.FirstOrDefaultAsync(c => c.clientId == id);
            return result;
        }

        public async Task<Portefeuille> UpdateAsync(Portefeuille entity)
        {
            _myDbContext.portefeuilles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
