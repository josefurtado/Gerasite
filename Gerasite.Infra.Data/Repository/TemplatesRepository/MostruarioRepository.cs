using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Repositorio;

namespace Gerasite.Infra.Data.Repository.TemplatesRepository
{
    public class MostruarioRepository : Repository<Mostruario>
    {
        public MostruarioRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
