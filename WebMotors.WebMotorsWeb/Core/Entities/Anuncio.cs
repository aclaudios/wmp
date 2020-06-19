using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebMotors.Core.Entities
{

    [Table("tb_AnuncioWebmotors")]
    public class Anuncio : EntidadeBase
    {
        [Key]
        [Column("Id")]
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
        public int Quilometragem { get; set; }

        [Required]
        public string Observacao { get; set; }
    }
}
