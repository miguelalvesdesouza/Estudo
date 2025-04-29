using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizFlow.Application.Events
{
    public class AgendamentoCriadoEvent
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; }
        public string Servico { get; set; }
        public DateTime DataHora { get; set; }
    }
}