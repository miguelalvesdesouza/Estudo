using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaculdadeAPI.Dados.Dto
{
    /*Classes Dtos são definidas para realizar a transferência de dados dentro do sistema, dessa forma o cliente
      não tem acesso à certas informações*/
    public class AlteraAlunoDto
    {
  
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Email { get; set; }
        public int CursoId { get; set; }

    }
}
