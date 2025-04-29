using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agenda> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração explícita do relacionamento
            modelBuilder.Entity<Agenda>()
                .HasOne(a => a.Cliente)  // Cada Agendamento tem um Cliente
                .WithMany(c => c.Agendamentos)  // Cada Cliente pode ter vários Agendamentos
                .HasForeignKey(a => a.ClienteId);  // A chave estrangeira

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Agendamentos)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);
        }
    }


}