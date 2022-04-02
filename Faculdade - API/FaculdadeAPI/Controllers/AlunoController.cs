using AutoMapper;
using FaculdadeAPI.Dados;
using FaculdadeAPI.Dados.Dto;
using FaculdadeAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        /*UTILIZANDO LISTA PARA CONFIGURAR CONTOLLER
        private static List<Aluno> alunos = new List<Aluno>();
        private static int Ra = 1;*/

        /*UTILIZANDO CONTEXT CRIADO PARA ACESSAR O BANCO*/
        private Context _context;
        //INICIALIZANDO AUTOMAPPER
        private IMapper _mapper;
        public AlunoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAluno([FromBody] AdicionaAlunoDto alunoDto)
        {
            Aluno aluno = _mapper.Map<Aluno>(alunoDto);
            /* COMANDO COM LISTA
            aluno.Ra = Ra++;
            alunos.Add(aluno); */

            //COMANDO COM CONTEXT
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaAluno), new {Ra = aluno.Ra }, aluno );


            /* CreatedAtAction - deve receber como argumentos:
             * actionName: O nome da ação a ser usada para gerar a URL.
             * routeValues: É o objeto que contém os valores que serão passados ​​para o método GET na rota nomeada. 
             Será usado para retornar o objeto criado
             * value: O valor de conteúdo a formatar no corpo da entidade. */
        }

        [HttpGet]
        public IActionResult ListaAlunos()
        {
            /* UTILIZANDO LISTA
            return Ok(alunos); */
            
            //UTILIZANDO CONTEXT
            return Ok(_context.Alunos);

            /* Ok e NotFound são do tipo ObjectResult que implementa a interface IActionResult */
        }

        [HttpGet("{ra}")]
        public IActionResult BuscaAluno(int ra)
        {
            /* UTILIZANDO LISTA
            Aluno aluno = alunos.FirstOrDefault(aluno => aluno.Ra == ra); */

            //UTILIZANDO CONTEXT
            Aluno aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Ra == ra);
            if (aluno != null)
            {
                /* var buscaAlunoDto = new BuscaAlunoDto
                {
                    NomeDto = aluno.Nome,
                    IdadeDto = aluno.Idade,
                    EmailDto = aluno.Email,
                    HoraConsulto = DateTime.Now
                }; */
                //LÓGICA UTILIZANDO AUTOMAPPER
                var buscaAlunoDto = _mapper.Map<BuscaAlunoDto>(aluno);
                return Ok(buscaAlunoDto);
            }
            return NotFound();

            /* FirstOrDefault - retorna da lista de alunos o primeiro elemento ou o que encontrar
            sendo o primeiro elmento um aluno e deve conter um Ra igual ao ra passado */

            /*////////////////Mesma lógica////////////////////////////////
            foreach(Aluno aluno in alunos)
            {
                if(aluno.Ra == ra)
                {
                    return aluno;
                }
            }     
            return null;
            ///////////////////////////////////////////////////////////*/
        }

        [HttpPut("{ra}")]
        public IActionResult AlteraDados(int ra, [FromBody] AlteraAlunoDto alunoDto)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Ra == ra);
            if(aluno == null)
            {
                return NotFound();
            }
            /*
            aluno.Nome = alunoDto.Nome;
            aluno.Idade = alunoDto.Idade;
            aluno.Email = alunoDto.Email;
            */
            //LÓGICA UTILIZANDO AUTOMAPPER
            _mapper.Map(alunoDto, aluno);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{ra}")]
        public IActionResult DeletaAluno(int ra)
        {
            Aluno aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Ra == ra);
            if (aluno == null)
            {
                return NotFound();
            }
            _context.Remove(aluno);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
