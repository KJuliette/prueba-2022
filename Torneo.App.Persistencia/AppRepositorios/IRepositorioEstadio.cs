using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioEstadio
    {
        public Estadio AddEstadio(Estadio estadio, int idMunicipio);
        public Estadio GetEstadio(int idEstadio);
        public IEnumerable<Estadio> GetAllEstadios();

    }
}