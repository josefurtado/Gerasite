using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Application.Services.TemplatesService
{
    public class MostruarioService : IMostruarioService
    {
        private readonly IUnityOfWork _Uow;

        public MostruarioService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Mostruario>().Remove(id);
        }

        public IEnumerable<Mostruario> Get()
        {
            return _Uow.GetRepository<Mostruario>().GetAll();
        }

        public Mostruario Get(int id)
        {
            return _Uow.GetRepository<Mostruario>().GetById(id);
        }

        public void SaveOrUpdate(Mostruario entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Mostruario>().Add(entity);
                _Uow.GetRepository<Mostruario>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Mostruario>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Mostruario>().Dispose();
        }
    }
}
