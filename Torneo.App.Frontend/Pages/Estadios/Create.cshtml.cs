using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;


namespace Torneo.App.Frontend.Pages.Estadios
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioMunicipio _repoMunicipio;

        public Estadio estadio { get; set; }
        public IEnumerable<Municipio> municipios { get; set; }
        
        public CreateModel(IRepositorioEstadio repoEstadio, IRepositorioMunicipio repoMunicipio)
        {
            _repoEstadio = repoEstadio;
            _repoMunicipio = repoMunicipio;
        }
        public void OnGet()
        {
            estadio = new Estadio();
            municipios = _repoMunicipio.GetAllMunicipios();
        }

        public IActionResult OnPost(Estadio estadio, int idMunicipio)
        {
            /* if (ModelState.IsValid){ */
                _repoEstadio.AddEstadio(estadio, idMunicipio);
                return RedirectToPage("Index");
          /*   }
            else{
                municipios = _repoMunicipio.GetAllMunicipios();
                return Page();
            } */
        }
    }
}
