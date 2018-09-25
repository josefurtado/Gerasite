using Gerasite.Dominio.Entidades.Templates;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces.ITemplatesService
{
    public interface IComercialService
    {
        IEnumerable<Comercial> Get();
        Comercial Get(int id);
        void SaveOrUpdate(Comercial entity);
        void Delete(int id);
    }
}
