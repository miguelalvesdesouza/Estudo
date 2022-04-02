using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Gerenciamento
{
    public class LivroEmprestado : ICadastro
    {
        public string Livro { get; set; }
        public int Data { get; set; }
        public LivroEmprestado(string livro, int data)
        {
            Livro = livro;
            Data = data;
        }

        //método aplicado da interface ICadastro
        public bool PegarLivro(Pessoas pessoa)
        {
           if(pessoa != null)
            {
                return true;
            }
            return false;
        }
    }
}
