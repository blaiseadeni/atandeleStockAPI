using ATD_API.Data;
using ATD_API.Entities;
using ATD_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATD_API.Repositories.Classes
{
    public class UtilisateurRepo : IUtilisateur
    {
        private readonly MyDbContext _myDbContext;

        public UtilisateurRepo(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<Utilisateur> AddAsync(Utilisateur entity)
        {
            var result = _myDbContext.utilisateurs.Add(entity);
            await _myDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = _myDbContext.utilisateurs.FirstOrDefault(a => a.id == id);
            if (result != null)
            {
                _myDbContext.utilisateurs.Remove(result);
                return await _myDbContext.SaveChangesAsync() > -1;
            }

            return false;
        }

        public async Task<IEnumerable<Utilisateur>> FindAllAsync()
        {
            var result = await _myDbContext.utilisateurs.ToListAsync();
            return result;
        }

        public async Task<Utilisateur> FindByIdAsync(Guid id)
        {
            var result = await _myDbContext.utilisateurs.FirstOrDefaultAsync(c => c.id == id);
            return result;
        }

        public async Task<Utilisateur> UpdateAsync(Utilisateur entity)
        {
            _myDbContext.utilisateurs.Update(entity);
            await _myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

    }
}
