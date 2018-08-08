using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;

namespace Gerasite.Infra.Data.Repositorio
{
    public class SessaoRepository : Repository<Sessao>, ISessaoRepository
    {
        public SessaoRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
