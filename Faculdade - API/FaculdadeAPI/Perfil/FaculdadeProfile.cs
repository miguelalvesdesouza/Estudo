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
    //Classe Profile armazena os perfis necessários para o automappes
    //automapper é o responsável por realizar o mapeamento entre diferentes classes
    public class FaculdadeProfile : Profile
    {
        public FaculdadeProfile()
        {
            // Utilizando automapper para Conversoes de classes
            CreateMap<AdicionaAlunoDto, Aluno>();
            CreateMap<Aluno, BuscaAlunoDto>();
            CreateMap<AlteraAlunoDto, Aluno>();

        }
    }
}
