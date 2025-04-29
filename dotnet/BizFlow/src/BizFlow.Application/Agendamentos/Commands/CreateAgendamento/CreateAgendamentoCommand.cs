using System;
using MediatR;
namespace BizFlow.Application.Agendamentos.Commands.CreateAgendamento
{
    public class CreateAgendamentoCommand : IRequest<Guid>
    {
        public string ClienteNome { get; set; }
        public string Servico { get; set; }
        public DateTime DataHora { get; set; }
    }
}


// Esse é o comando que a API vai mandar.

// Quando receber, o sistema vai criar o agendamento.

// Retorna o Guid (ID) do agendamento criado.