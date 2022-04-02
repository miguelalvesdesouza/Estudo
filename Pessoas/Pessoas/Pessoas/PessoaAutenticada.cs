using Pessoas.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Pessoas
{
    public class PessoaAutenticada : Pessoa, IAutenticarPessoa
    {
        public string Senha { get; set; }
        public string Email { get; set; }

        public PessoaAutenticada(string nome, int idade, string email, string senha) : base(nome, idade, email, senha)
        {
        }

        public bool Autenticar(string email, string senha)
        {
            return Email == email && Senha == senha;
        }
    }
}
