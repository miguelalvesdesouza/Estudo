using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoApi.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}