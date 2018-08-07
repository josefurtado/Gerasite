using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;
using System.Linq;

namespace Gerasite.Infra.Data.Repositorio
{
    public class TextoRepository : Repository<Texto>, ITextoRepository
    {
        public TextoRepository(GerasiteContext context)
            : base(context)
        {

        }

        public Texto GetByNome(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Nome.Contains(nome));
        }
    }
}
