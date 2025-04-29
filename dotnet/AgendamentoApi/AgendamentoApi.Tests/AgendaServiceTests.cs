using Xunit;
using AgendamentoApi.Services;
using AgendamentoApi.Models;
using AgendamentoApi.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AgendamentoApi.Tests
{
    public class AgendaServiceTests
    {
        private readonly Mock<ClienteService> _mockClienteService;
        private readonly AgendaService _agendaService;
        private readonly DbContextOptions<DataContext> _options;

        public AgendaServiceTests()
        {
            // Configurando o banco de dados em memória
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Criando instância do DataContext em memória
            var context = new DataContext(_options);

            // Criando mock do ClienteService
            _mockClienteService = new Mock<ClienteService>();

            // Instanciando o AgendaService
            _agendaService = new AgendaService(context, _mockClienteService.Object);
        }

        [Fact]
        public void Dispose()
        {
            using (var context = new DataContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }


        [Fact]
        public async Task BuscarTodosAgendamentos_DeveRetornarListaDeAgendamentos()
        {
            // Arrange: Preenchemos a base de dados com dados fictícios
            using (var context = new DataContext(_options))
            {
                Dispose();
                context.Agendamentos.Add(new Agenda { Data = System.DateTime.Now, ClienteId = 1, Cliente = new Cliente { Name = "Cliente 1", Phone = "13999991111" } });
                context.Agendamentos.Add(new Agenda { Data = System.DateTime.Now.AddDays(1), ClienteId = 2, Cliente = new Cliente { Name = "Cliente 2", Phone = "13999992222" } });
                await context.SaveChangesAsync();
            }

            // Act: Chama o método que estamos testando
            List<Agenda> result;
            using (var context = new DataContext(_options))
            {
                result = await _agendaService.BuscarTodosAgendamentos();
            }

            Console.WriteLine($"Resultado: {string.Join(", ", result.Select(a => a.Cliente.Name))}");

            // Assert: Verifica se o resultado é uma lista com 2 agendamentos
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task BuscarAgendamento_DeveRetornarAgendamentoEspecifico()
        {
            // Arrange: Adiciona um agendamento na base de dados
            using (var context = new DataContext(_options))
            {
                Dispose();
                context.Agendamentos.Add(new Agenda { Data = System.DateTime.Now, ClienteId = 1, Cliente = new Cliente { Name = "Cliente 1", Phone = "13999991111" } });
                await context.SaveChangesAsync();
            }

            // Act: Chama o método para buscar o agendamento
            var result = await _agendaService.BuscarAgendamento(1);

            // Assert: Verifica se o agendamento foi encontrado
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task Agendar_DeveAdicionarNovoAgendamento()
        {
            Dispose();
            // Arrange: Cria um novo agendamento
            var novoAgendamento = new Agenda { Data = System.DateTime.Now.AddDays(2), ClienteId = 3, Cliente = new Cliente { Name = "Cliente 3", Phone = "13999991111" } };

            // Act: Chama o método para adicionar o novo agendamento
            var result = await _agendaService.Agendar(novoAgendamento);

            // Assert: Verifica se o agendamento foi adicionado com sucesso
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }
}
