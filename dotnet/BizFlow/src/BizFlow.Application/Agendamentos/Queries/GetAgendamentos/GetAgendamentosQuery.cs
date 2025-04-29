using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Domain.Entities;
using MediatR;

namespace BizFlow.Application.Agendamentos.Queries.GetAgendamentos
{
    public class GetAgendamentosQuery : IRequest<List<Agendamento>>
    {
    }
}