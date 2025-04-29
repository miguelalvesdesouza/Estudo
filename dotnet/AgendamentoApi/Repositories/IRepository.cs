using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}