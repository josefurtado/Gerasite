using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Application.Services.TemplatesService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnityOfWork _Uow;

        public PortfolioService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Portfolio>().Remove(id);
        }

        public IEnumerable<Portfolio> Get()
        {
            return _Uow.GetRepository<Portfolio>().GetAll();
        }

        public Portfolio Get(int id)
        {
            return _Uow.GetRepository<Portfolio>().GetById(id);
        }

        public void SaveOrUpdate(Portfolio entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Portfolio>().Add(entity);
                _Uow.GetRepository<Portfolio>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Portfolio>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Portfolio>().Dispose();
        }
    }
}
