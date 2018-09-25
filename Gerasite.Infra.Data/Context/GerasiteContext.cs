using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Mappings;
using Gerasite.Infra.Data.Mappings.TemplatesMap;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gerasite.Infra.Data.Context
{
    public class GerasiteContext : DbContext
    {
        public GerasiteContext()
            : base("GerasiteConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.CommandTimeout = 300;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateArquivado> TemplatesArquivados { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Comercial> Comercials { get; set; }
        public DbSet<Mostruario> Mostruarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TemplateMap());
            modelBuilder.Configurations.Add(new TemplateArquivadoMap());
            modelBuilder.Configurations.Add(new PortfolioMap());
            modelBuilder.Configurations.Add(new ComercialMap());
            modelBuilder.Configurations.Add(new MostruarioMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

      
    }
}
