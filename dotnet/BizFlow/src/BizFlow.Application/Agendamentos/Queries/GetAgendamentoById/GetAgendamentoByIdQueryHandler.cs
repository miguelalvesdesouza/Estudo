using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Infrastructure.Persistence;
using BizFlow.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.Application.Agendamentos.Queries.GetAgendamentoById
{
    public class GetAgendamentoByIdQueryHandler : IRequestHandler<GetAgendamentoByIdQuery, Agendamento?>
    {
        private readonly BizFlowDbContext _context;

        public GetAgendamentoByIdQueryHandler(BizFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Agendamento?> Handle(GetAgendamentoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        }
    }
}

// Busca no banco pelo Id.

// Retorna o agendamento ou null se não achar.