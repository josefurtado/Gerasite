using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;

namespace Gerasite.Infra.Data.Repositorio
{
    public class LogoRepository : Repository<Logo>, ILogoRepository
    {
        public LogoRepository(GerasiteContext context) : base(context)
        {

        }
    }
}
