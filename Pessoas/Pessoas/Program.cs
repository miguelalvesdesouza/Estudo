using Pessoas.Pessoas;
using Pessoas.Sistema;
using System;

namespace Pessoas
{
    class Program
    {
        private static string Teste(string palavra1, string palavra2)
        {

            return $"{palavra1} {palavra2}";
        }

        private static void Retorno()
        {

            Console.WriteLine(Teste("palavra1", "palavra2"));
        }

        private static void Cadastrar()
        {
            Console.Write("Insira a quantidade de pessoas: ");
            int quantidade = int.Parse(Console.ReadLine());
            for (int i = 1; i <= quantidade; i++)
            {
                Console.WriteLine("Dados Pessoa " + i);
                Console.Write("Insira seu nome: ");
                string Nome = Console.ReadLine();
                Console.Write("Insira sua idade: ");
                int Idade = int.Parse(Console.ReadLine());
                Console.Write("Insira seu email: ");
                string Email = Console.ReadLine();
                Console.Write("Insira sua senha: ");
                string Senha = Console.ReadLine();

                Pessoa pessoa = new Pessoa(Nome, Idade, Email, Senha);
                PessoaAutenticada pessoaAutenticada = new(pessoa.Nome, pessoa.Idade, pessoa.Email, pessoa.Senha);
                pessoaAutenticada.Autenticar(pessoa.Email, pessoa.Senha);

                string[] arrayPessoa = new string[]
                {
                    new string(Senha)
                };
                Console.WriteLine(pessoa);
                Console.WriteLine(arrayPessoa[quantidade-1]);
                
            }
        }

        private static void Login(string emailLogin, string senhaLogin)
        {
                
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            SistemaAutenticacao sistemaautenticacao = new SistemaAutenticacao();

            Pessoa pessoaLogin = new Pessoa("miguel", 21, emailLogin, senhaLogin);
            //PessoaAutenticada login = new PessoaAutenticada(email, senha);
            //Console.WriteLine(miguel);
            //sistemaautenticacao.Logar(miguel, email, senha);
            Console.WriteLine("\n\n" + sistemaautenticacao.Logar(pessoaLogin, email, senha));

        }


        static void Main(string[] args)
        {
            //PessoaAutenticada login = new PessoaAutenticada("miguel@", "123");

            Retorno();

            int menu;
            

            do
            {
                Console.WriteLine("Insira a opção desejada: ");
                Console.WriteLine("1 - Cadastrar usuário\t2 - Realizar login\t3 - Dados do usuário\t4 - Cancelar operação");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Login("miguel@","123");
                        break;
                    case 3:
                        Dados();
                        break;
                }
            }
            while (menu != 4);


            void Dados()
            {

            }

        }
    }
}
