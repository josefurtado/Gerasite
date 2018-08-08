using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class PaginaMap : EntityTypeConfiguration<Pagina>
    {
        public PaginaMap()
        {
            ToTable("Pagina");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasMaxLength(50);

            Property(x => x.PosicaoHorizontal);

            Property(x => x.PosicaoVertical);

            HasRequired(x => x.Menu);

            HasRequired(x => x.Template);
        }
    }
}
