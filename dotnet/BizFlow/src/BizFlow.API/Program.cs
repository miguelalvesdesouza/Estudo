using System.Reflection;
using BizFlow.Application.Events;
using BizFlow.Consumers.Consumers;
using BizFlow.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Postgres");
Console.WriteLine($"[DEBUG] Connection string usada: {connectionString}");

builder.Services.AddDbContext<BizFlowDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();


builder.Services.AddMassTransit(x =>
{
    // x.AddConsumer<AgendamentoCriadoConsumer>();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(new Uri("amqp://localhost:5672"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(ctx);
        //cfg.Message<AgendamentoCriadoEvent>(x => x.SetEntityName("BizFlow.Application.Events:AgendamentoCriadoEvent"));
    });
});

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("BizFlow.Application")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
