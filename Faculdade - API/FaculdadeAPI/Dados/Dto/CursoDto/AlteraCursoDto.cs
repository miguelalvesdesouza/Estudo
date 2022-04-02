using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Dados.Dto
{
    public class AlteraCursoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Duracao { get; set; }
    }
}
