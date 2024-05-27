using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace T2_Arriola_Alonso.Models
{
    public class Distribuidor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre del Distribuidor es obligatorio")]
        public string NombreDistribuidor { get; set; }
        [Required(ErrorMessage = "La razon social es obligatoria")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El año de inicio operacion es obligatorio")]
        [Range(1900,3000,ErrorMessage="El año debe variar entre 1900 y 3000")]
        public int AnioInicioOperacion { get; set; }
        [Required(ErrorMessage = "El contacto es obligatorio")]
        public string Contacto { get; set; }
    }
}
