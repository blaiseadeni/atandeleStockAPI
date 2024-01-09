using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class InventaireComptableRepo : IIventaitaireComptable
    {
        private readonly MyDbContext _myDbContext;

        public InventaireComptableRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<InvetaireComptable> AddAsync(InvetaireComptable entity)
        {
            var result = _myDbContext.inventaireComptables.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.inventaireComptables.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.inventaireComptables.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<InvetaireComptable>> FindAllAsync()
        {
            var result = await _myDbContext.inventaireComptables.ToListAsync();
            return result;
        }

        public async Task<InvetaireComptable> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.inventaireComptables.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<InvetaireComptable> UpdateAsync(InvetaireComptable entity)
        {
            _myDbContext.inventaireComptables.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
