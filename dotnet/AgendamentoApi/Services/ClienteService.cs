using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using AgendamentoApi.Models;
using AgendamentoApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Services
{
    public class ClienteService
    {
        private readonly DataContext _context;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService() { }
        public ClienteService(DataContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }
        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            return await _clienteRepository.BuscarTodosClientes();
        }

        public async Task<Cliente> BuscarCliente(int id)
        {
            return await _clienteRepository.BuscarCliente(id);
        }

        public async Task<Cliente> AtualizarCliente(int id, Cliente clienteAtualizado)
        {
            var cliente = await BuscarCliente(id);
            if (cliente == null)
                return null;

            cliente.Name = clienteAtualizado.Name;
            cliente.Phone = clienteAtualizado.Phone;

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            if (cliente == null)
                return null;

            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}