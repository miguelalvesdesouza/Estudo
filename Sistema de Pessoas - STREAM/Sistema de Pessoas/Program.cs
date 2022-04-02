using System;
using System.IO;
using Sistema_de_Pessoas.Cadastros;
using Sistema_de_Pessoas.Logins;

namespace Sistema_de_Pessoas
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        Logar();
                        break;
                    case 3:
                        //Dados();
                        break;
                }
            }
            while (menu != 4);


            static string Cadastrar()
            {

                Console.Write("Insira seu Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Insira Idade: ");
                int idade = int.Parse(Console.ReadLine());
                Console.Write("Insira seu Email: ");
                string email = Console.ReadLine();
                Console.Write("Insira sua Senha: ");
                string senha = Console.ReadLine();
                Console.WriteLine("\n");

                var pessoa = new Cadastro(nome, idade, email, senha);
                pessoa.Cadastrar();

                return nome;

            }



            static void Logar()
            {
                using (var fs = new FileStream("cadastros.txt", FileMode.Open))
                using (var leitor = new StreamReader(fs))
                {
                    var linha = leitor.ReadLine();
                    var campo = linha.Split(',');
                    var nome = campo[0];
                    var idade = int.Parse(campo[1]);
                    leitor.Close();

                    Console.Write("Email: ");
                    string emailLogin = Console.ReadLine();
                    Console.Write("Senha: ");
                    string senhaLogin = Console.ReadLine();

                    var pessoaLogin = new Login(nome, idade, emailLogin, senhaLogin);

                    bool status = pessoaLogin.Logar(emailLogin, senhaLogin);

                    if (status)
                    {
                        Console.WriteLine("Acesso Permitido");
                    }
                    else
                    {
                        Console.WriteLine("Acesso Negado");
                    }
                }

            }
        }
    }
}
