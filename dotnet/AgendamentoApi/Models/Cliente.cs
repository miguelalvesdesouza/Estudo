using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }

        [MaxLength(11, ErrorMessage = "Este campo deve conter no máximo 11 caracteres")]
        public string Phone { get; set; }

        public List<Agenda> Agendamentos { get; set; } = new List<Agenda>();

    }
}