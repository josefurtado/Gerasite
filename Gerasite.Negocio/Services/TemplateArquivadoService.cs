using System.Collections.Generic;
using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using Gerasite.Infra.Data.Transaction;

namespace Gerasite.Negocio.Services
{
    class TemplateArquivadoService : ITemplateArquivadoService
    {
        private readonly IUnityOfWork _Uow;

        public TemplateArquivadoService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<TemplateArquivado>().Remove(id);
        }

        public IEnumerable<TemplateArquivado> Get()
        {
            return _Uow.GetRepository<TemplateArquivado>().GetAll();
        }

        public TemplateArquivado Get(int id)
        {
            return _Uow.GetRepository<TemplateArquivado>().GetById(id);
        }

        public void SaveOrUpdate(TemplateArquivado entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<TemplateArquivado>().Add(entity);
                _Uow.GetRepository<TemplateArquivado>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<TemplateArquivado>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<TemplateArquivado>().Dispose();
        }
    }
}
