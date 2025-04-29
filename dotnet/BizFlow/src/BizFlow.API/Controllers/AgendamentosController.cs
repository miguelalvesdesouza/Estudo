using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BizFlow.Application.Agendamentos.Commands.CreateAgendamento;
using BizFlow.Application.Agendamentos.Commands.DeleteAgendamento;
using BizFlow.Application.Agendamentos.Commands.UpdateAgendamento;
using BizFlow.Application.Agendamentos.Queries.GetAgendamentoById;
using BizFlow.Application.Agendamentos.Queries.GetAgendamentos;
using BizFlow.Application.Events;
using BizFlow.Domain.Entities;
using BizFlow.Infrastructure.Persistence;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BizFlow.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendamentosController : Controller
    {
        private readonly IMediator _mediator;


        public AgendamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateAgendamentoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Criar), new { id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var agendamento = await _mediator.Send(new GetAgendamentoByIdQuery(id));
            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpGet]
        public async Task<IActionResult> ObterAgendamentos()
        {
            var agendamento = await _mediator.Send(new GetAgendamentosQuery());
            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UpdateAgendamentoCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id da URL diferente do corpo da requisição");

            var atualizado = await _mediator.Send(command);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var sucesso = await _mediator.Send(new DeleteAgendamentoCommand(id));

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}

// O Controller não conhece o DbContext direto.

// Ele só envia o Command ou Query para o MediatR e pronto.

// MediatR acha o Handler respectivo e executa.