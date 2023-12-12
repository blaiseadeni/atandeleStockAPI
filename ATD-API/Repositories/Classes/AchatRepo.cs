using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class AchatRepo : IAchat
    {
        private readonly MyDbContext _myDbContext;

        public AchatRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Achat> AddAsync(Achat entity)
        {
            var result = _myDbContext.achats.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.achats.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.achats.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Achat>> FindAllAsync()
        {
            var result = await _myDbContext.achats.ToListAsync();
            return result;
        }

        public async Task<Achat> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.achats.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Achat> UpdateAsync(Achat entity)
        {
            _myDbContext.achats.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

    }
}
