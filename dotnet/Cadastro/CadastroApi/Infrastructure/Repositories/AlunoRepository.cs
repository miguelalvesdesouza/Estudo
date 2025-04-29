using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroApi.Domain.Entities;
using CadastroApi.Domain.Interfaces;
using CadastroApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroApi.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Aluno>> GetAllAlunoAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            return await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}