using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CadastroApi.Application.Commands
{
    public class CreateAlunoCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}