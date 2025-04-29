using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CadastroBlazor.Services
{
    public class AlunoService
    {
        private readonly HttpClient _http;

        public AlunoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> CreateAluno(string nome, string telefone)
        {
            var aluno = new
            {
                Nome = nome,
                Telefone = telefone
            };
            return await _http.PostAsJsonAsync("api/aluno", aluno);
        }
    }
}