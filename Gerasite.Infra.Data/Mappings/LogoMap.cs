using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class LogoMap : EntityTypeConfiguration<Logo>
    {
        public LogoMap()
        {
            ToTable("Logo");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CaminhoImagem)
                .HasMaxLength(50);

            Property(x => x.ArquivoImagem)
                .HasMaxLength(100);

            HasRequired(x => x.Template);
        }
    }
}
