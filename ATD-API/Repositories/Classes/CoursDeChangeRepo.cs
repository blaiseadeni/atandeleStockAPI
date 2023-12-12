using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class CoursDeChangeRepo : ICoursDeChange
    {

        private readonly MyDbContext _myDbContext;

        public CoursDeChangeRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<CoursDeChange> AddAsync(CoursDeChange entity)
        {
            var result = _myDbContext.coursDeChanges.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.coursDeChanges.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.coursDeChanges.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<CoursDeChange>> FindAllAsync()
        {
            var result = await _myDbContext.coursDeChanges.ToListAsync();
            return result;
        }

        public async Task<CoursDeChange> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.coursDeChanges.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<CoursDeChange> UpdateAsync(CoursDeChange entity)
        {
            _myDbContext.coursDeChanges.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
