using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Estadios
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioMunicipio _repoMunicipio;

        public Estadio estadio { get; set; }
        public SelectList MunicipioOptions { get; set; }
        public int MunicipioSelected { get; set; }

        public EditModel(IRepositorioEstadio repoEstadio, IRepositorioMunicipio repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }

        public IActionResult OnGet(int id)
        {
            estadio = _repoEstadio.GetEstadio(id);
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            MunicipioSelected = estadio.Municipio.Id;
            if (estadio == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Estadio estadio, int idMunicipio)
        {
            _repoEstadio.UpdateEstadio(estadio, idMunicipio);
            return RedirectToPage("Index");
        }
    }
}