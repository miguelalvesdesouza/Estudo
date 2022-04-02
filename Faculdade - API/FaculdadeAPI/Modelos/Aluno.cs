using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Modelos
{
    public class Aluno
    {
        [Key]
        [Required]
        public int Ra { get;  set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
