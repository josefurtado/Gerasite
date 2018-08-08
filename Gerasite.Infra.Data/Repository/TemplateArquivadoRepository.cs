using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Repository;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Repositorio;
using System;

namespace Gerasite.Infra.Data.Repository
{
    public class TemplateArquivadoRepository : Repository<TemplateArquivado>, ITemplateArquivadoRepository
    {
        public TemplateArquivadoRepository(GerasiteContext context)
            : base(context)
        {

        }

        public TemplateArquivado GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
