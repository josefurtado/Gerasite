using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;

namespace Gerasite.Infra.Data.Repositorio
{
    public class PaginaRepository : Repository<Pagina>, IPaginaRepository
    {
        public PaginaRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
