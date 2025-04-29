using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BizFlow.Application.Agendamentos.Commands.DeleteAgendamento
{
    public class DeleteAgendamentoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteAgendamentoCommand() { }
        public DeleteAgendamentoCommand(Guid id)
        {
            Id = id;
        }
    }
}