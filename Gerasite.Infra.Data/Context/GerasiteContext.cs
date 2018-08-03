using Gerasite.Dominio.Entidades;
using Gerasite.Infra.Data.Mappings;
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
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Texto> Textos { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateArquivado> TemplatesArquivados { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Logo> Logos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TextoMap());
            modelBuilder.Configurations.Add(new TemplateMap());
            modelBuilder.Configurations.Add(new TemplateArquivadoMap());
            modelBuilder.Configurations.Add(new PaginaMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new LogoMap());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
