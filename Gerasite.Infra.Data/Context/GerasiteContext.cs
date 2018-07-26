using Gerasite.Dominio.Entidades;
using Gerasite.Infra.Data.Mappings;
using System.Data.Entity;

namespace Gerasite.Infra.Data.Context
{
    public class GerasiteContext : DbContext
    {
        public GerasiteContext()
            : base("GerasiteConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
