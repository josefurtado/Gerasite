using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using Gerasite.Dominio.Repository;
using Gerasite.Infra.Data.Context;
using System.Linq;

namespace Gerasite.Infra.Data.Repositorio
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(GerasiteContext context)
            : base(context)
        {

        }

        public Template GetByNome(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}
