using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroApi.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno([FromBody] CreateAlunoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

    }
}