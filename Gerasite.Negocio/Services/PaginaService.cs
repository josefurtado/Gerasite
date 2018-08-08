using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Negocio.Services
{
    public class PaginaService : IPaginaService
    {
        private readonly IUnityOfWork _Uow;

        public PaginaService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Pagina>().Remove(id);
        }

        public IEnumerable<Pagina> Get()
        {
            return _Uow.GetRepository<Pagina>().GetAll();
        }

        public Pagina Get(int id)
        {
            return _Uow.GetRepository<Pagina>().GetById(id);
        }

        public void SaveOrUpdate(Pagina entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Pagina>().Add(entity);
                _Uow.GetRepository<Pagina>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Pagina>().Update(entity);
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Pagina>().Dispose();
        }
    }
}
