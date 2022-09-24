using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio

{
    public class Arbitro {
        public int Id { get; set; }
        [Display(Name = "Nombre del arbitro")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Número de documento")]
        [Required(ErrorMessage = "El documento es obligatorio")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El colegio es obligatorio")]
        public string Colegio { get; set;}
    }

}