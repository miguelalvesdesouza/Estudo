using BizFlow.Application.Events;
using BizFlow.Consumers.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<AgendamentoCriadoConsumer>();
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(new Uri("amqp://localhost:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                //cfg.ConfigureEndpoints(ctx);
                cfg.ReceiveEndpoint("agendamento-criado-consumer", e =>
                {
                    e.Bind<AgendamentoCriadoEvent>();
                    e.ConfigureConsumer<AgendamentoCriadoConsumer>(ctx);
                });
            });
        });

        services.AddLogging(config => config.AddConsole());
    }).Build();

var busControl = builder.Services.GetRequiredService<IBusControl>();

await busControl.StartAsync();

Console.WriteLine("Consumer rodando! Pressione CTRL+C para sair.");
await builder.WaitForShutdownAsync();


