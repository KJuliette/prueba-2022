using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();

        public Partido AddPartido(Partido partido, int local, int visitante, int idEstadio, int idArbitro)
        {
            var localEncontrado = _dataContext.Equipos.Find(local);
            var visitanteEncontrado = _dataContext.Equipos.Find(visitante);
            var estadioEncontrado = _dataContext.Estadios.Find(idEstadio);
            var arbitroEncontrado = _dataContext.Arbitros.Find(idArbitro);
            partido.Local = localEncontrado;
            partido.Visitante = visitanteEncontrado;
            partido.Estadio = estadioEncontrado;
            partido.Arbitro = arbitroEncontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }


        public IEnumerable<Partido> GetAllPartidos()
        {
            var partidos = _dataContext.Partidos
                .Include(e => e.Local)
                .Include(e => e.Visitante)
                .Include(e => e.Arbitro)
                .Include(e => e.Estadio)
                .ToList();
            return partidos;
        }

        public Partido GetPartido(int idPartido)
        {
            var partidoEncontrado = _dataContext.Partidos
            .Where(e => e.Id == idPartido)
            .Include(e => e.Local)
            .Include(e => e.Visitante)
            .Include(e => e.Arbitro)
            .Include(e => e.Estadio)
            .FirstOrDefault();
            return partidoEncontrado;
        }
    }
}