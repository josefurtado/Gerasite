using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;

namespace Gerasite.Infra.Data.Repositorio
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
