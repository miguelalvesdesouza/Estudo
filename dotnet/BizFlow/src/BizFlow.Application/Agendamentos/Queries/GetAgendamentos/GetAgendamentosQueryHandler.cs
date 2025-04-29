using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Domain.Entities;
using BizFlow.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.Application.Agendamentos.Queries.GetAgendamentos
{
    public class GetAgendamentosQueryHandler : IRequestHandler<GetAgendamentosQuery, List<Agendamento>>
    {
        private readonly BizFlowDbContext _context;

        public GetAgendamentosQueryHandler(BizFlowDbContext context)
        {
            _context = context;
        }


        public async Task<List<Agendamento>> Handle(GetAgendamentosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Agendamentos.ToListAsync();
        }
    }
}