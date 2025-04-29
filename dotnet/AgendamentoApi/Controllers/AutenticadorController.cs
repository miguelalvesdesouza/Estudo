using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoApi.Models;
using AgendamentoApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgendamentoApi.Controllers
{
    [Route("api/auth")]
    public class AutenticadorController : Controller
    {
        private readonly IConfiguration _config;
        private readonly LoginRequestService _loginRequestService;

        public AutenticadorController(IConfiguration config, LoginRequestService loginRequestService)
        {
            _config = config;
            _loginRequestService = loginRequestService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "123") // Simulação de login
            {
                var token = _loginRequestService.GenerateJwtToken(request.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuário ou senha inválidos");
        }
    }
}