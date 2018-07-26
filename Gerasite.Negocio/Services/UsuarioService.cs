using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnityOfWork _Uow;
        
        public UsuarioService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Usuario>().Remove(id);
        }

        public IEnumerable<Usuario> Get()
        {
            return _Uow.GetRepository<Usuario>().GetAll();
        }

        public Usuario Get(int id)
        {
            return _Uow.GetRepository<Usuario>().GetById(id);
        }

        public void SaveOrUpdate(Usuario entity)
        {
            if(entity.Id == 0)
            {
                _Uow.GetRepository<Usuario>().Add(entity);
                _Uow.GetRepository<Usuario>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Usuario>().Update(entity);
                
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Usuario>().Dispose();
        }

        
    }
}
