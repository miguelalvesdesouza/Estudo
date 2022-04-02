using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Sistema
{
    public interface IAutenticarPessoa
    {
        bool Autenticar(string email, string senha);
    }

}
