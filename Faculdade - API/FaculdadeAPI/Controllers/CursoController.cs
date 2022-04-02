using AutoMapper;
using FaculdadeAPI.Dados;
using FaculdadeAPI.Dados.Dto;
using FaculdadeAPI.Dados.Dto.CursoDto;
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
    public class CursoController : ControllerBase
    {
        private Context _context;
        private IMapper _mapper;

        public CursoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaCurso([FromBody] AdicionaCursoDto cursoDto)
        {
            Curso curso = _mapper.Map<Curso>(cursoDto);
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaCurso), new { Id = curso.Id }, curso);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCurso(int id)
        {
            Curso curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
            if (curso != null)
            {
                var buscaCursoDto = _mapper.Map<BuscaCursoDto>(curso);
                return Ok(buscaCursoDto);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListaCurso()
        {
            return Ok(_context.Cursos);
        }

        [HttpPut("{id}")]
        public IActionResult AlteraCurso([FromBody] AlteraCursoDto alteraCursoDto, int id)
        {
            Curso curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
            if(curso != null)
            {
                _mapper.Map(alteraCursoDto, curso);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCurso(int id)
        {
            Curso curso = _context.Cursos.FirstOrDefault(curso => curso.Id == id);
            if (curso != null)
            {
                _context.Remove(curso);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
