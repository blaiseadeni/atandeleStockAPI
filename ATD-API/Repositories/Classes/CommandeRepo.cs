using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace ATD_API.Repositories.Classes
{
    public class CommandeRepo : ICommande
    {
        private readonly MyDbContext _myDbContext;

        public CommandeRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Commande> AddAsync(Commande entity)
        {
            var result = _myDbContext.commandes.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.commandes.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _myDbContext.commandes.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Commande>> FindAllAsync()
        {
            var result = await _myDbContext.commandes.Include(a => a.DetailCommandes).ToListAsync();
            return result;
        }

        public async Task<Commande> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.commandes.Include(a => a.DetailCommandes).FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Commande> UpdateAsync(Commande entity)
        {
            _myDbContext.commandes.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
