using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizFlow.Domain
{
    public class Servico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }

    }
}