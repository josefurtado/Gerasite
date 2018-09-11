using Gerasite.Dominio.Entidades;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces
{
    public interface ITemplateService
    {
        IEnumerable<Template> Get();
        Template Get(int id);
        void SaveOrUpdate(Template entity);
        void Delete(int id);
    }
}
