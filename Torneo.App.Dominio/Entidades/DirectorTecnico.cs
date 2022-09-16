using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio
{
    public class DirectorTecnico
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Director técnico")]
        public string Nombre { get; set; }
        [Display(Name = "Documento del Director técnico")]
        public string Documento { get; set; }
        [Display(Name = "Nombre del Director técnico")]
        public string Telefono { get; set; }
    }
}