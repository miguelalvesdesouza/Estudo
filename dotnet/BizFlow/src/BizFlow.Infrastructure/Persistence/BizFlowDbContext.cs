using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.Infrastructure.Persistence
{
    public class BizFlowDbContext : DbContext
    {
        public BizFlowDbContext(DbContextOptions<BizFlowDbContext> options) : base(options) { }

        public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>().ToTable("Agendamentos");
            base.OnModelCreating(modelBuilder);
        }
    }
}