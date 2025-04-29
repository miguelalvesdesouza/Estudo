using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroApi.Application.Commands;
using CadastroApi.Domain.Entities;
using CadastroApi.Domain.Interfaces;
using MediatR;

namespace CadastroApi.Application.Handlers
{
    public class CreateAlunoHandler : IRequestHandler<CreateAlunoCommand, int>
    {
        private readonly IAlunoRepository _alunorepository;

        public CreateAlunoHandler(IAlunoRepository alunoRepository)
        {
            _alunorepository = alunoRepository;
        }

        public async Task<int> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = new Aluno(request.Nome, request.Telefone);
            await _alunorepository.AddAsync(aluno);
            return aluno.Id;
        }
    }
}