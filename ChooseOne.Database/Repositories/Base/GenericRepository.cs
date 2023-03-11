using ChooseOne.Core.Domain.Base;
using ChooseOne.Database.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseOne.Database.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly ChooseOneContext _context;

        public DbSet<T> _dbSet { get; set; }

        public GenericRepository()
        {
            _context = new ChooseOneContext();
            _context.CreateDataBase();
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var obj = _dbSet.Find(id);
            if (obj != null)
            {
                await RemoveAsync(obj);
            }
        }

        public async Task UpdateAsync(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
