using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Negocio.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnityOfWork _Uow;

        public MenuService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Menu>().Remove(id);
        }

        public IEnumerable<Menu> Get()
        {
            return _Uow.GetRepository<Menu>().GetAll();
        }

        public Menu Get(int id)
        {
            return _Uow.GetRepository<Menu>().GetById(id);
        }

        public void SaveOrUpdate(Menu entity)
        {
            if(entity.Id == 0)
            {
                _Uow.GetRepository<Menu>().Add(entity);
                _Uow.GetRepository<Menu>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Menu>().Update(entity);
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Menu>().Dispose();
        }
    }
}
