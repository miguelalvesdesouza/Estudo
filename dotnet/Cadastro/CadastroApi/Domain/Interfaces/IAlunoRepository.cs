using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroApi.Domain.Entities;

namespace CadastroApi.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAllAlunoAsync();
        Task<Aluno> GetAlunoById(int id);
        Task AddAsync(Aluno aluno);
    }
}