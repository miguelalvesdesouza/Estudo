using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Pessoas
{
     public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //Construtor da Classe Pessoa
        public Pessoa(string nome, int idade, string email, string senha)
        {
            Nome = nome;
            this.Idade = idade;
            this.Email = email;
            this.Senha = senha;
        }

        public override string ToString()
        {
            return $"\n{Nome} \n{Idade} \n{Email} \n{Senha}";
        }

    }
}
