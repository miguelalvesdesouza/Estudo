using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using AgendamentoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Services
{
    public class AgendaService
    {
        private readonly DataContext _context;
        private readonly ClienteService _clienteService;

        public AgendaService() { }
        public AgendaService(DataContext context, ClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        public async Task<List<Agenda>> BuscarTodosAgendamentos()
        {
            return await _context.Agendamentos
                .Include(c => c.Cliente)
                .ToListAsync();
        }

        public async Task<Agenda> BuscarAgendamento(int? id)
        {
            var agenda = await _context.Agendamentos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (agenda == null)
                return null;

            await _context.SaveChangesAsync();
            return agenda;
        }

        public async Task<Agenda> Agendar(Agenda agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }
    }
}