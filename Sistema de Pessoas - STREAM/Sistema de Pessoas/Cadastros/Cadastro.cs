using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Pessoas.Cadastros
{
    public class Cadastro 
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Senha { get; }

        public Cadastro(string nome, int idade, string email, string senha)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
            Senha = senha;
        }

        public void Cadastrar()
        {
            using (var cadastros = new FileStream("cadastros.txt", FileMode.Create))
            using (var cadastrar = new StreamWriter(cadastros))
            {
                cadastrar.Flush();
                cadastrar.WriteLine($"{Nome},{Idade},{Email},{Senha}");
                
            }
        }


    }

}
