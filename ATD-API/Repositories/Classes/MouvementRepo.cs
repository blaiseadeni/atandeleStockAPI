using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class MouvementRepo : IMouvement
    {
        private readonly MyDbContext _myDbContext;

        public MouvementRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Mouvement> AddAsync(Mouvement entity)
        {
            var result = _myDbContext.mouvements.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.mouvements.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.mouvements.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Mouvement>> FindAllAsync()
        {
            var result = await _myDbContext.mouvements.ToListAsync();
            return result;
        }

        public async Task<Mouvement> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.mouvements.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Mouvement> UpdateAsync(Mouvement entity)
        {
            _myDbContext.mouvements.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
