using System.ComponentModel.DataAnnotations;

namespace RegistroSeccion.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

    }
}
