using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMotors.WebMotorsWeb.Models
{
    public class AnuncioViewModel
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        
        public string Marca { get; set; }

        [Required]
        [StringLength(45)]
        public string Modelo { get; set; }

        [Required]
        [StringLength(45)]
        public string Versao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]        
        public string Quilometragem { get; set; }

        [Required]
        public string Observacao { get; set; }
    }
}
