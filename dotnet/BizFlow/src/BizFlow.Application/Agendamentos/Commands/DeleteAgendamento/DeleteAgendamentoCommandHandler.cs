using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.Application.Agendamentos.Commands.DeleteAgendamento
{
    public class DeleteAgendamentoCommandHandler : IRequestHandler<DeleteAgendamentoCommand, bool>
    {
        BizFlowDbContext _context;

        public DeleteAgendamentoCommandHandler(BizFlowDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (agendamento == null)
                return false;

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}