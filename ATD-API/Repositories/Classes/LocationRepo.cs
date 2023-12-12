using ATD_API.Data;
using ATD_API.Dtos;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class LocationRepo : ILocation
    {
        private readonly MyDbContext _myDbContext;

        public LocationRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Location> AddAsync(Location entity)
        {
            var result = _myDbContext.locations.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.locations.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.locations.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Location>> FindAllAsync()
        {
            var result = await _myDbContext.locations.ToListAsync();
            return result;
        }

        public async Task<Location> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.locations.FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Location> UpdateAsync(Location entity)
        {
            _myDbContext.locations.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
