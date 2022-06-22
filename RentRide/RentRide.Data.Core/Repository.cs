using Microsoft.EntityFrameworkCore;
using RentRide.Data.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentRide.Data.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _db;

        protected readonly DbSet<T> Data;

        protected Repository(DbContext context)
        {
            _db = context;
            Data = _db.Set<T>();
        }


        public async Task CreateAsync(T item)
        {
            Data.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            Data.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            var result = await Data.ToListAsync();
            return result;
        }

        public async Task<T> FindByIdAsync(params object[] KeyValues)
        {
            var result = await Data.FindAsync(KeyValues);
            return result;
        }

        public async Task UpdateAsync(T item)
        {
            Data.Update(item);
            await _db.SaveChangesAsync();  
        }
    }
}