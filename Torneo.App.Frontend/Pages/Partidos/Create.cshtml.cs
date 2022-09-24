using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioArbitro _repoArbitro;

        public Partido partido { get; set; }
        public IEnumerable<Equipo> equipos { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }
        public IEnumerable<Arbitro> arbitros { get; set; }

        public CreateModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo, IRepositorioEstadio repoEstadio, IRepositorioArbitro repoArbitro)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            _repoEstadio = repoEstadio;
            _repoArbitro = repoArbitro;
        }

        public void OnGet()
        {
            partido = new Partido();
            equipos = _repoEquipo.GetAllEquipos();
            estadios = _repoEstadio.GetAllEstadios();
            arbitros = _repoArbitro.GetAllArbitros();
        }

        public IActionResult OnPost(Partido partido, int local, int visitante, int idEstadio, int idArbitro)
        {
                _repoPartido.AddPartido(partido, local, visitante, idEstadio, idArbitro);
                return RedirectToPage("Index");
        }
    }
}
