using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    }
}