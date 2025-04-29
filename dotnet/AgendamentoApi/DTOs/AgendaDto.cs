using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoApi.DTOs
{
    public class AgendaDto
    {
        [Required]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido")]
        public int ClienteId { get; set; }
    }
}