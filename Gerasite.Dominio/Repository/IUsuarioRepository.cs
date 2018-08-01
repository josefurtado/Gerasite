using Gerasite.Dominio.Entidades;

namespace Gerasite.Dominio.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByNome(string nome);
    }
}
