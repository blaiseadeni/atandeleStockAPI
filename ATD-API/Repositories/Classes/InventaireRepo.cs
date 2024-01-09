using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class InventaireRepo : IInventaire
    {
        private readonly MyDbContext _myDbContext;

        public InventaireRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Inventaire> AddAsync(Inventaire entity)
        {
            var result = _myDbContext.inventaires.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.inventaires.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.inventaires.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Inventaire>> FindAllAsync()
        {
            var result = await _myDbContext.inventaires.ToListAsync();
            return result;
        }

        public async Task<Inventaire> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.inventaires.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Inventaire> UpdateAsync(Inventaire entity)
        {
            _myDbContext.inventaires.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
