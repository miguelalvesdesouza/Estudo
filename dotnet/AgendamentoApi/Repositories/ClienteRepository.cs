using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using AgendamentoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            return await (
            from cliente in _context.Clientes
            join agendamento in _context.Agendamentos
            on cliente.Id equals agendamento.ClienteId into agendamentos
            select new Cliente
            {
                Id = cliente.Id,
                Name = cliente.Name,
                Phone = cliente.Phone,
                Agendamentos = agendamentos.ToList()
            }).ToListAsync();

        }

        public async Task<Cliente> BuscarCliente(int id)
        {
            return await _context.Clientes
                .Include(a => a.Agendamentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}