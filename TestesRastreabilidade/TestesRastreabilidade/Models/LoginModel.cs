using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesRastreabilidade.Repository;

namespace TestesRastreabilidade.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

    }
}
