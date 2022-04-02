using AutoMapper;
using FaculdadeAPI.Dados.Dto;
using FaculdadeAPI.Dados.Dto.CursoDto;
using FaculdadeAPI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Perfil
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<AdicionaCursoDto, Curso>();
            CreateMap<AlteraCursoDto, Curso>();
            CreateMap<Curso, BuscaCursoDto>()
                .ForMember(curso => curso.Alunos, opts => opts
                .MapFrom(curso => curso.Alunos.Select
                (a => new { a.Ra, a.Nome })));
        }
            
    }
}
