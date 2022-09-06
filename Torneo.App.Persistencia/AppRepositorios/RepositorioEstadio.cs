using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioEstadio : IRepositorioEstadio
    {
        private readonly DataContext _dataContext = new DataContext();

        public Estadio AddEstadio(Estadio estadio, int idMunicipio)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            estadio.Municipio = municipioEncontrado;
            var estadioInsertado = _dataContext.Estadios.Add(estadio);
            _dataContext.SaveChanges();
            
            return estadioInsertado.Entity;
        }

        public IEnumerable<Estadio> GetAllEstadios()
        {
            var estadios = _dataContext.Estadios

                .Include(e => e.Municipio)
                .ToList();

            return estadios;
        }


    }
}