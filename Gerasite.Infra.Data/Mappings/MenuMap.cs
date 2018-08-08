using Gerasite.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.PaginaAdicionada);

            Property(x => x.PosicaoHorizontal);

            Property(x => x.PosicaoVertical);

            HasRequired(x => x.Template);
        }
    }
}
