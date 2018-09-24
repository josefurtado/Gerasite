using Gerasite.Dominio.Entidades.Templates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings.TemplatesMap
{
    public class MostruarioMap : EntityTypeConfiguration<Mostruario>
    {
        public MostruarioMap()
        {
            ToTable("Mostruario");
            Property(x => x.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Titulo)
                .HasMaxLength(50);
            Property(x => x.TituloSessao1)
                .HasMaxLength(30);
            Property(x => x.TituloSessao2)
                .HasMaxLength(30);
            Property(x => x.TextoSessao2)
                .HasMaxLength(450);
            Property(x => x.TituloSessao3)
               .HasMaxLength(30);
            Property(x => x.TextoSessao3)
                .HasMaxLength(450);
            Property(x => x.TituloSessao4)
               .HasMaxLength(30);
            Property(x => x.TextoSessao4)
                .HasMaxLength(450);
            Property(x => x.LegendaImg1)
               .HasMaxLength(10);
            Property(x => x.LegendaImg2)
               .HasMaxLength(10);
            Property(x => x.LegendaImg3)
               .HasMaxLength(10);
        }
    }
}
