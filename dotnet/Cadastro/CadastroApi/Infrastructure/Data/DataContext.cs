using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
    }
}