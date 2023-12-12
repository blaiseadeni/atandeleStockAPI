using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class FournisseurRepo : IFournisseur
    {
        private readonly MyDbContext _myDbContext;

        public FournisseurRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Fournisseur> AddAsync(Fournisseur entity)
        {
            var result = _myDbContext.fournisseurs.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.fournisseurs.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.fournisseurs.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Fournisseur>> FindAllAsync()
        {
            var result = await _myDbContext.fournisseurs.ToListAsync();
            return result;
        }

        public async Task<Fournisseur> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.fournisseurs.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Fournisseur> UpdateAsync(Fournisseur entity)
        {
            _myDbContext.fournisseurs.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
