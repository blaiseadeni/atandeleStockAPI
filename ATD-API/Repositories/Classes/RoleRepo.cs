using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class RoleRepo : IRole
    {
        private readonly MyDbContext _myDbContext;

        public RoleRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Role> AddAsync(Role entity)
        {
            var result = _myDbContext.roles.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.roles.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.roles.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Role>> FindAllAsync()
        {
            var result = await _myDbContext.roles.ToListAsync();
            return result;
        }

        public async Task<Role> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.roles.FirstOrDefaultAsync(c => c.id == id);
            return result;

        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            _myDbContext.roles.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
