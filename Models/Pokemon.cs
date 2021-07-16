using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pokeAPI.Models
{
    public class Pokemon
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O campo Dex é obrigatório")]
        public string Dex { get; set; }
    }
}
