using System.ComponentModel.DataAnnotations;

namespace Clase_2.Data
{
    public class VehiculosModel
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength (7, ErrorMessage = "El numero maximo de caracteres es 7")]
        public string Placa { get; set; }
        [Display(Name ="Año de Fabricación")]
        [Required (ErrorMessage = "El campo es requerido")]
        public string Anio_Fabricacion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Kilometraje { get; set; }

    }
}
