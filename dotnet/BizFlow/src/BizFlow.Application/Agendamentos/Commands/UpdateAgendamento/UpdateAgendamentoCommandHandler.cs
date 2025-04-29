using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.Application.Agendamentos.Commands.UpdateAgendamento
{
    public class UpdateAgendamentoCommandHandler : IRequestHandler<UpdateAgendamentoCommand, bool>
    {
        private readonly BizFlowDbContext _context;

        public UpdateAgendamentoCommandHandler(BizFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (agendamento == null)
                return false;

            agendamento.ClienteNome = request.ClienteNome;
            agendamento.Servico = request.Servico;
            agendamento.DataHora = request.DataHora;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}