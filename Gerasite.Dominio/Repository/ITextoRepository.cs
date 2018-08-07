using Gerasite.Dominio.Entidades;

namespace Gerasite.Dominio.Interfaces
{
    public interface ITextoRepository : IRepository<Texto>
    {
        Texto GetByNome(string nome);
    }
}
