using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;
using System.Linq;

namespace Gerasite.Infra.Data.Repositorio
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GerasiteContext context)
            : base(context)
        {

        }

        public Usuario GetByNome(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Nome.Contains(nome));
        }
    }
}
