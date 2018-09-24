using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Repositorio;

namespace Gerasite.Infra.Data.Repository.TemplatesRepository
{
    public class PortfolioRepository : Repository<Portfolio>
    {
        public PortfolioRepository(GerasiteContext context) : base(context)
        {

         }
    }
}

