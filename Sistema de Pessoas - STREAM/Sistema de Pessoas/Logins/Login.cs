using Sistema_de_Pessoas.Cadastros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Pessoas.Logins
{
    public class Login : Cadastro
    {
        public string emailLogin { get; set; }
        public string senhaLogin { get; set; }
        public Login(string nome, int idade, string email, string senha) : base(nome, idade, email, senha)
        {
            emailLogin = email;
            senhaLogin = senha;
        }


        public bool Logar(string emailTentativa, string senhaTentativa)
        {
            using (var fs = new FileStream("cadastros.txt", FileMode.Open))
            using (var leitor = new StreamReader(fs))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var campo = linha.Split(',');
                    emailTentativa = campo[2];
                    senhaTentativa = campo[3];



                    //Console.WriteLine(campo[2]);
                    //Console.WriteLine(campo[3]);
                    //Console.WriteLine(emailLogin);
                    //Console.WriteLine(senhaLogin);
                }


                return emailLogin == emailTentativa && senhaLogin == senhaTentativa;

            }

        }



    }

}
