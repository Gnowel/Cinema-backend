using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CinemaContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(CinemaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            if(entity == null)
                return false;

            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            
            if(entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }

            return false;

        }

        public Task<bool> Update(T entity)
        {
            if (entity == null)
                return Task.FromResult(false);

            _dbSet.Update(entity);
            return Task.FromResult(true);
        }
    }
}
