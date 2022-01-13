using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TaxRatingContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(TaxRatingContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.AsNoTracking().ToListAsync();
        }


        public async Task Add(T entity)
        {
            _db.Add(entity);
            await SaveChangesAsync();
        }


        public async Task Update(T entity)
        {
            _db.Update(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _db.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task AddRange(IEnumerable<T> entites)
        {
            await _context.Set<T>().AddRangeAsync(entites);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
