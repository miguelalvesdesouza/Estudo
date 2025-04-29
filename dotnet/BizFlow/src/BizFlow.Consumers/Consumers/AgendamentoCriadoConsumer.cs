using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using BizFlow.Application.Events;

namespace BizFlow.Consumers.Consumers
{
    public class AgendamentoCriadoConsumer : IConsumer<AgendamentoCriadoEvent>
    {
        private readonly ILogger<AgendamentoCriadoConsumer> _logger;

        public AgendamentoCriadoConsumer(ILogger<AgendamentoCriadoConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<AgendamentoCriadoEvent> context)
        {
            _logger.LogInformation("Recebido: Cliente {ClienteNome}, Serviço {Servico}, Data {DataHora}",
                context.Message.ClienteNome,
                context.Message.Servico,
                context.Message.DataHora);
            return Task.CompletedTask;
        }
    }
}