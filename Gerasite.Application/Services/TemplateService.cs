using Gerasite.Dominio.Entidades;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;

namespace Gerasite.Application.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IUnityOfWork _Uow;

        public TemplateService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Template>().Remove(id);
        }

        public IEnumerable<Template> Get()
        {
            return _Uow.GetRepository<Template>().GetAll();
        }

        public Template Get(int id)
        {
            return _Uow.GetRepository<Template>().GetById(id);
        }

        public void SaveOrUpdate(Template entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Template>().Add(entity);
                _Uow.GetRepository<Template>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Template>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Template>().Dispose();
        }


    }
}
