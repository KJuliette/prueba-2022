using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio

{
    public class Arbitro {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Colegio { get; set;}
    }

}