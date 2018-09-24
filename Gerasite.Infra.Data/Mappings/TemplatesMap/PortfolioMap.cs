using Gerasite.Dominio.Entidades.Templates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings.TemplatesMap
{
    public class PortfolioMap : EntityTypeConfiguration<Portfolio>
    {
        public PortfolioMap()
        {
            ToTable("Portfolio");
            Property(x => x.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo)
                .HasMaxLength(50);
            Property(x => x.Profissao)
               .HasMaxLength(50);
            Property(x => x.Texto1)
               .HasMaxLength(250);
            Property(x => x.Texto2)
               .HasMaxLength(250);
            Property(x => x.Citacao)
               .HasMaxLength(150);
            Property(x => x.Telefone)
               .HasMaxLength(10);
            Property(x => x.Email)
               .HasMaxLength(50);
        }
    }
}
