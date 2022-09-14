using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, int local, int visitante, int idEstadio, int idArbitro);
        public IEnumerable<Partido> GetAllPartidos();
        public Partido GetPartido(int idPartido);
    }
}