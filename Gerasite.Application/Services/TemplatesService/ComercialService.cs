using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Application.Services.TemplatesService
{
    public class ComercialService : IComercialService
    {
        private readonly IUnityOfWork _Uow;

        public ComercialService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Comercial>().Remove(id);
        }

        public IEnumerable<Comercial> Get()
        {
            return _Uow.GetRepository<Comercial>().GetAll();
        }

        public Comercial Get(int id)
        {
            return _Uow.GetRepository<Comercial>().GetById(id);
        }

        public void SaveOrUpdate(Comercial entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Comercial>().Add(entity);
                _Uow.GetRepository<Comercial>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Comercial>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Comercial>().Dispose();
        }
    }
}
