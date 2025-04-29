using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BizFlow.Application.Agendamentos.Commands.UpdateAgendamento
{
    public class UpdateAgendamentoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; }
        public string Servico { get; set; }
        public DateTime DataHora { get; set; }
    }
}