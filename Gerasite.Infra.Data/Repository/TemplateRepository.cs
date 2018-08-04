using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Repository;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Repositorio;
using System;

namespace Gerasite.Infra.Data.Repository
{
    class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(GerasiteContext context)
            : base(context)
        {

        }

        public Template GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
