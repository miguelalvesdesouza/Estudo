using MediatR;
using BizFlow.Infrastructure.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using BizFlow.Domain.Entities;

namespace BizFlow.Application.Agendamentos.Commands.CreateAgendamento
{
    public class CreateAgendamentoCommandHandler : IRequestHandler<CreateAgendamentoCommand, Guid>
    {
        private readonly BizFlowDbContext _context;
        public CreateAgendamentoCommandHandler(BizFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAgendamentoCommand request, CancellationToken cancellationToken)
        {
            var agendamento = new Agendamento
            {
                Id = Guid.NewGuid(),
                ClienteNome = request.ClienteNome,
                Servico = request.Servico,
                DataHora = request.DataHora.ToUniversalTime()
            };

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync(cancellationToken);

            return agendamento.Id;
        }
    }
}

// Recebe o CreateAgendamentoCommand.

// Cria um novo Agendamento.

// Salva no banco (BizFlowDbContext).

// Retorna o ID gerado.