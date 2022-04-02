using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Gerenciamento
{
    public interface ICadastro 
    {
        //Todo método criado em interface deve ser implementado em suas classes extendidas
        public bool PegarLivro(Pessoas pessoa);
        
    }
}
