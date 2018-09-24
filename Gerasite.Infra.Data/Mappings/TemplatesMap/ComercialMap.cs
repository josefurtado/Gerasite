using Gerasite.Dominio.Entidades.Templates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gerasite.Infra.Data.Mappings.TemplatesMap
{
    public class ComercialMap : EntityTypeConfiguration<Comercial>
    {
        public ComercialMap()
        {
            ToTable("Comercial");
            Property(x => x.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo)
                .HasMaxLength(50);
            Property(x => x.TextoSobre)
               .HasMaxLength(250);
            Property(x => x.TextoCitacao)
               .HasMaxLength(50);
            Property(x => x.TextoFuncionamento)
               .HasMaxLength(50);
            Property(x => x.TituloPrato1)
               .HasMaxLength(20);
            Property(x => x.TextoPrato1)
               .HasMaxLength(50);

            Property(x => x.TituloPrato2)
               .HasMaxLength(20);
            Property(x => x.TextoPrato2)
               .HasMaxLength(50);

            Property(x => x.TituloPrato3)
               .HasMaxLength(20);
            Property(x => x.TextoPrato3)
               .HasMaxLength(50);

            Property(x => x.TituloPrato4)
               .HasMaxLength(20);
            Property(x => x.TextoPrato4)
               .HasMaxLength(50);

            Property(x => x.Telefone)
               .HasMaxLength(10);
            Property(x => x.Email)
               .HasMaxLength(50);
            Property(x => x.Endereco)
              .HasMaxLength(50);
        }
    }
}
