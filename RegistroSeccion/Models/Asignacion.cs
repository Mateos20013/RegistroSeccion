﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroSeccion.Models
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        
        public Carrera Carrera { get; set; }

        [ForeignKey("Carrera")]
        public int IdCarrera { get; set; }

    }
}
