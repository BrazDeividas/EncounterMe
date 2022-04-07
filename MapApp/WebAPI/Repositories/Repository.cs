using EncounterMe;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public readonly BaseDbContext context;

        public DbSet<T> entities { get; set; }
        
        public Repository(BaseDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await entities.AddAsync(entity);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                entities.Remove(await entities.FindAsync(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var DbEntity = entities.Find(entity.Id);
                context.Entry(DbEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
