using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Models;

namespace AgendamentoApi.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> BuscarTodosClientes();
        Task<Cliente> BuscarCliente(int id);
    }
}