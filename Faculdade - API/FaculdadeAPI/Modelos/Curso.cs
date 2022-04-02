using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FaculdadeAPI.Modelos
{
    public class Curso
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Duracao { get; set; }
        [JsonIgnore]
        public virtual List<Aluno> Alunos { get; set; }
    }
}
