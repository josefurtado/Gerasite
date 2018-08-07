using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Negocio.Services
{
    public class TextoService : ITextoService
    {
        private readonly IUnityOfWork _Uow;
        
        public TextoService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Texto>().Remove(id);
        }

        public IEnumerable<Texto> Get()
        {
            return _Uow.GetRepository<Texto>().GetAll();
        }

        public Texto Get(int id)
        {
            return _Uow.GetRepository<Texto>().GetById(id);
        }

        public void SaveOrUpdate(Texto entity)
        {
            if(entity.Id == 0)
            {
                _Uow.GetRepository<Texto>().Add(entity);
                _Uow.GetRepository<Texto>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Texto>().Update(entity);
                
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Usuario>().Dispose();
        }

        
    }
}
