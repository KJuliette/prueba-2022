using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class DataContext : DbContext
    {
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<DirectorTecnico> DirectoresTecnicos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Posicion> Posiciones { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Arbitro> Arbitros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Torneo2");
                optionsBuilder.UseSqlServer("Server=tcp:misionticronin.database.windows.net,1433;Initial Catalog=Torneo2;Persist Security Info=False;User ID=admin_1;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;EnableRetryOnFailure");
                //optionsBuilder.UseSqlServer("Data Source = MSI\\SQLEXPRESS; Initial Catalog = Torneo2; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}