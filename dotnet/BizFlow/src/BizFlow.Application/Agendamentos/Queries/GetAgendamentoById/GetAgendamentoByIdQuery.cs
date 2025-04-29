using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Domain.Entities;
using MediatR;

namespace BizFlow.Application.Agendamentos.Queries.GetAgendamentoById
{
    public class GetAgendamentoByIdQuery : IRequest<Agendamento?>
    {
        public Guid Id { get; set; }

        public GetAgendamentoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

// IRequest<Agendamento?> → esse query vai devolver um Agendamento (ou null se não achar).
// Recebe o Id que queremos buscar.