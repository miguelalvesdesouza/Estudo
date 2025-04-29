using System.Text;
using AgendamentoApi.Data;
using AgendamentoApi.Repositories;
using AgendamentoApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); //Banco de dados em memória
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));//Banco de dados PostGree
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<LoginRequestService>();
builder.Services.AddScoped<AgendaService>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurar autenticação JWT
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
    };
});
builder.Services.AddAuthorization();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddControllers();
builder.Services.AddScoped<ClienteService>();

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

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
