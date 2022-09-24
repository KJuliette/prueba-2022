using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioArbitro _repoArbitro;
        private readonly IRepositorioEstadio _repoEstadio;

        public Partido partido { get; set; }
        public SelectList EquipoOptions { get; set; }
        public SelectList ArbitroOptions { get; set; }
        public SelectList EstadioOptions { get; set; }
        public int EquipoSelected { get; set; }
        public int ArbitroSelected { get; set; }
        public int EstadioSelected { get; set; }

        public EditModel(IRepositorioEstadio repoEstadio, IRepositorioEquipo repoEquipo, IRepositorioArbitro repoArbitro, IRepositorioEstadio _repoEstadio)
        {
            _repoEstadio = repoEstadio;
            _repoEquipo = repoEquipo;
            _repoArbitro = repoArbitro;
            _repoEstadio = repoEstadio;
        }

        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EstadioOptions = new SelectList(_repoArbitro.GetAllArbitros(), "Id", "Nombre");
            ArbitroOptions = new SelectList(_repoEstadio.GetAllEstadios(), "Id", "Nombre");
            EquipoSelected = partido.Local.Id;
            ArbitroSelected = partido.Arbitro.Id;
            EstadioSelected = partido.Estadio.Id;
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Partido partido, int local, int visitante, int idArbitro, int idEstadio)
        {
            _repoPartido.UpdatePartido(partido, local, visitante, idArbitro, idEstadio);
            return RedirectToPage("Index");
        }
    }
}
