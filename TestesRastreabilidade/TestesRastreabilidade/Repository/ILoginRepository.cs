using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesRastreabilidade.Models;

namespace TestesRastreabilidade.Repository
{
    interface ILoginRepository
    {
        bool Get(string usuario, string senha);
    }
}
