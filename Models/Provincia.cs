using System.ComponentModel.DataAnnotations;

namespace Clase_2.Models
{
    public class Provincia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo es requerido")]
        public string Nombre { get; set; }
    }
}