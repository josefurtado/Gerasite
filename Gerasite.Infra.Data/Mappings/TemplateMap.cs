using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class TemplateMap : EntityTypeConfiguration<Template>
    {
        public TemplateMap()
        {
            ToTable("Template");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NomeTemplate)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.DescricaoTemplate)
                .HasMaxLength(250);

            Property(x => x.CorTemplate)
                .HasMaxLength(12);

            //HasRequired(x => x.Sessao);
        }
    }
}
