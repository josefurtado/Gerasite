using Gerasite.Dominio.Entidades;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces
{
    public interface ITemplateArquivadoService
    {
        IEnumerable<TemplateArquivado> Get();
        TemplateArquivado Get(int id);
        void SaveOrUpdate(TemplateArquivado entity);
        void Delete(int id);
    }
}
