using Gerasite.Dominio.Entidades.Templates;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces.ITemplatesService
{
    public interface IMostruarioService
    {
        IEnumerable<Mostruario> Get();
        Mostruario Get(int id);
        void SaveOrUpdate(Mostruario entity);
        void Delete(int id);
    }
}
