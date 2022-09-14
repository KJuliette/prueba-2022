using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio
{
    public class DirectorTecnico
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Director técnico")]
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
    }
}