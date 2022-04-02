using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Pessoas
    {
        public string Nome { get;  }
        public string Endereco { get; }
        public int Telefone { get; }


        public Pessoas(string nome, string endereco, int telefone)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
