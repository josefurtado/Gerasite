using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Repositorio;

namespace Gerasite.Infra.Data.Repository.TemplatesRepository
{
    public class ComercialRepository : Repository<Comercial>
    {
        public ComercialRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
