using FaculdadeAPI.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Dados
{
    //Classe de contexto são classes responsáveis para fazer a conexão com o banco de dados
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt){}

        //CRIANDO RELACIONAMENTO DE TABELAS
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>()
                .HasOne(aluno => aluno.Curso)
                .WithMany(curso => curso.Alunos)
                .HasForeignKey(aluno => aluno.CursoId);
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
