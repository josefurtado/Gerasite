using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class TextoMap : EntityTypeConfiguration<Texto>
    {
        public TextoMap()
        {
            ToTable("Texto");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Conteudo)
                .HasMaxLength(200);

            Property(x => x.CorTexto)
                .HasMaxLength(10);

            Property(x => x.PosicaoHorizontal);

            Property(x => x.PosicaoVertical);
        }
    }
}
