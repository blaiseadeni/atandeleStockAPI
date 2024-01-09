using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class LoginRepo : ILogin
    {
        private readonly MyDbContext _myDbContext;

        public LoginRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Login> AddAsync(Login entity)
        {
            var result = _myDbContext.logins.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.logins.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.logins.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Login>> FindAllAsync()
        {
            var result = await _myDbContext.logins.ToListAsync();
            return result;
        }

        public async Task<Login> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.logins.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Login> UpdateAsync(Login entity)
        {
            _myDbContext.logins.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

    }
}

