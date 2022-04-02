using Biblioteca.Gerenciamento;
using System;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rael = new Pessoas("Rael", "Rua 1", 333333);
            var teste = new Teste(Rael.Nome, Rael.Endereco, Rael.Telefone);

            var livro = new LivroEmprestado("harry potter", 01);


            Console.WriteLine(livro.PegarLivro(Rael));







        }
    }
}
