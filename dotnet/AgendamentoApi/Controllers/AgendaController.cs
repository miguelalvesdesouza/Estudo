using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using AgendamentoApi.DTOs;
using AgendamentoApi.Models;
using AgendamentoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AgendamentoApi.Controllers
{
    [ApiController]
    [Route("agendamento/[controller]")]
    public class AgendaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ClienteService _clienteService;
        private readonly AgendaService _agendaService;


        public AgendaController(DataContext dataContext, AgendaService agendaService, ClienteService clienteService)
        {
            _dataContext = dataContext;
            _agendaService = agendaService;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Agenda>>> Get()
        {
            var agendamentos = await _agendaService.BuscarTodosAgendamentos();
            return agendamentos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Agenda>> GetById(int id)
        {
            var agendamentos = await _agendaService.BuscarAgendamento(id);
            return agendamentos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Agenda>> Post([FromBody] AgendaDto dto)
        {
            if (ModelState.IsValid)
            {
                var cliente = await _clienteService.BuscarCliente(dto.ClienteId);
                var agenda = new Agenda
                {
                    Data = dto.Data,
                    ClienteId = dto.ClienteId,
                    Cliente = cliente,
                };

                await _agendaService.Agendar(agenda);
                return agenda;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}