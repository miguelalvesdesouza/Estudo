using FaculdadeAPI.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Dados.Dto
{
    /*Classes Dtos são definidas para realizar a transferência de dados dentro do sistema, dessa forma o cliente
      não tem acesso à certas informações*/
    public class BuscaAlunoDto
    {
        [Key]
        [Required]
        public int Ra { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual Curso Curso { get; set; }
        public DateTime HoraConsulto { get; set; }
    }
}
