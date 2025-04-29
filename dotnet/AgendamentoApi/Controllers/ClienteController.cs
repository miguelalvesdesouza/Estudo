using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Data;
using AgendamentoApi.Models;
using AgendamentoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoApi.Controllers
{
    [ApiController]
    [Route("agendamento/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly DataContext _dataContext;

        public ClienteController(ClienteService clienteService, DataContext dataContext)
        {
            _clienteService = clienteService;
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var clientes = await _clienteService.BuscarTodosClientes();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var clientes = await _clienteService.BuscarCliente(id);
            return clientes;
        }

        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.CadastrarCliente(cliente);
                return cliente;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Put(
            int id,
            [FromBody] Cliente cliente)
        {
            var clienteAtualizado = await _clienteService.AtualizarCliente(id, cliente);
            if (clienteAtualizado == null)
                return NotFound();

            return Ok(clienteAtualizado);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var clienteDeletado = await _dataContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                _dataContext.Clientes.Remove(clienteDeletado);
                await _dataContext.SaveChangesAsync();
                return clienteDeletado;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}