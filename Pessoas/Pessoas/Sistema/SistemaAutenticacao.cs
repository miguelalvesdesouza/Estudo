using Pessoas.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Sistema
{
    public class SistemaAutenticacao
    {
        public bool Logar(Pessoa pessoa, string email, string senha)
        {
            //bool usuarioAutenticado = pessoaAutenticada.Autenticar(email, senha);
            if (email == pessoa.Email && senha == pessoa.Senha)
            {
                Console.WriteLine("Login realizado");
                return true;
            }
            else
            {
                Console.WriteLine("Usuário ou senha incorretos");
                return false;
            }
        }
    }
}
