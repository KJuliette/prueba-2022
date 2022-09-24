using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioArbitro : IRepositorioArbitro
    {
        private readonly DataContext _dataContext = new DataContext();

        public Arbitro AddArbitro(Arbitro arbitro)
        {
            var arbitroInsertado = _dataContext.Arbitros.Add(arbitro);
            _dataContext.SaveChanges();
            return arbitroInsertado.Entity;
        }

        public IEnumerable<Arbitro> GetAllArbitros()
        {
            return _dataContext.Arbitros;
        }

        public Arbitro GetArbitro(int idArbitro)
        {
            var arbitroEncontrado = _dataContext.Arbitros.Find(idArbitro);
            return arbitroEncontrado;
        }

    }
}