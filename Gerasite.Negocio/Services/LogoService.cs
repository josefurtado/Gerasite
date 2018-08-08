using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Negocio.Services
{
    public class LogoService : ILogoService
    {
        private readonly IUnityOfWork _Uow;

        public LogoService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Logo>().Remove(id);
        }

        public IEnumerable<Logo> Get()
        {
            return _Uow.GetRepository<Logo>().GetAll();
        }

        public Logo Get(int id)
        {
            return _Uow.GetRepository<Logo>().GetById(id);
        }

        public void SaveOrUpdate(Logo entity)
        {
            if(entity.Id == 0)
            {
                _Uow.GetRepository<Logo>().Add(entity);
                _Uow.GetRepository<Logo>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Logo>().Update(entity);
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Logo>().Dispose();
        }
    }
}
