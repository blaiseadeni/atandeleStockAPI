using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class LivraisonRepo : ILivraison
    {
        private readonly MyDbContext _myDbContext;

        public LivraisonRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public async Task<Livraison> AddAsync(Livraison entity)
        {
            var result = _myDbContext.livraisons.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.livraisons.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.livraisons.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;

        }

        public async Task<IEnumerable<Livraison>> FindAllAsync()
        {
            var result = await _myDbContext.livraisons.Include(d => d.DetailLivraisons).ToListAsync();
            return result;
        }

        public async Task<Livraison> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.livraisons.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Livraison> UpdateAsync(Livraison entity)
        {
            _myDbContext.livraisons.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
