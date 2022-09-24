using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< HEAD
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
=======

>>>>>>> d5ca79277bba564251be3de3effae9fb30d0cda9
namespace Torneo.App.Frontend.Pages.Posiciones
{
    public class EditModel : PageModel
    {
<<<<<<< HEAD
        private readonly IRepositorioPosicion _repoPosicion;
        public Posicion posicion { get; set; }
        public EditModel(IRepositorioPosicion repoPosicion)
        {
            _repoPosicion = repoPosicion;
        }
        public IActionResult OnGet(int id)
        {
            posicion = _repoPosicion.GetPosicion(id);
            if (posicion == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Posicion posicion)
        {
            _repoPosicion.UpdatePosicion(posicion);
            return RedirectToPage("Index");
=======
        public void OnGet()
        {
>>>>>>> d5ca79277bba564251be3de3effae9fb30d0cda9
        }
    }
}
