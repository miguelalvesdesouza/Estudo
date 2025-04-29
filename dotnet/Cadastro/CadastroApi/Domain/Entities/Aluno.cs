using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroApi.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }

        public Aluno() { }

        public Aluno(string nome, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório");

            if (telefone.Length != 11)
                throw new ArgumentException("Telefone inválido");

            Nome = nome;
            Telefone = telefone;
        }
    }
}