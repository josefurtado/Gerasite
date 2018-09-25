using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class TemplateArquivadoMap : EntityTypeConfiguration<TemplateArquivado>
    {
        public TemplateArquivadoMap()
        {
            ToTable("TemplateArquivado");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           /* Property(x => x.DataCriacao)
                .IsRequired();

            Property(x => x.NomeTemplate)
                .HasMaxLength(50);

            HasRequired(x => x.Template);

            HasRequired(x => x.Usuario);*/

        }
    }
}
