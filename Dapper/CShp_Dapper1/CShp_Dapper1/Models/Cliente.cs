using System;
using System.Collections.Generic;
using System.Text;

namespace CShp_Dapper1.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public int  Idade { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
    }
}
