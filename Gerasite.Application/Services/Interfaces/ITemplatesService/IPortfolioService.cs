using Gerasite.Dominio.Entidades.Templates;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces.ITemplatesService
{
    public interface IPortfolioService
    {
        IEnumerable<Portfolio> Get();
        Portfolio Get(int id);
        void SaveOrUpdate(Portfolio entity);
        void Delete(int id);
    }
}
