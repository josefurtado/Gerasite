using Gerasite.Dominio.Entidades;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Application.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly IUnityOfWork _Uow;

        public SessaoService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Sessao>().Remove(id);
        }

        public IEnumerable<Sessao> Get()
        {
            return _Uow.GetRepository<Sessao>().GetAll();
        }

        public Sessao Get(int id)
        {
            return _Uow.GetRepository<Sessao>().GetById(id);
        }

        public void SaveOrUpdate(Sessao entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Sessao>().Add(entity);
                _Uow.GetRepository<Sessao>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Sessao>().Update(entity);
            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Sessao>().Dispose();
        }
    }
}
