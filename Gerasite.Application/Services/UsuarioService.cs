using AutoMapper;
using Gerasite.Application.ViewModels;
using Gerasite.Dominio.Entidades;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Infra.Data.Transaction;
using System.Collections.Generic;
using Gerasite.Application.AutoMapper;

namespace Gerasite.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnityOfWork _Uow;
        private readonly IMapper _mapper;
        
        public UsuarioService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
            this._mapper = AutoMapperConfig.Mapper;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Usuario>().Remove(id);
        }

        public IEnumerable<UsuarioViewModel> Get()
        {
            var users = _Uow.GetRepository<Usuario>().GetAll();
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(users);
        }

        public UsuarioViewModel Get(int id)
        {
            var user = _Uow.GetRepository<Usuario>().GetById(id);
            return _mapper.Map<UsuarioViewModel>(user);
        }

        public void SaveOrUpdate(UsuarioViewModel entity)
        {
            try
            {
                var user = _mapper.Map<Usuario>(entity);
                
                if (entity.Id == 0)
                {
                    _Uow.GetRepository<Usuario>().Add(user);
                    _Uow.GetRepository<Usuario>().SaveChanges();
                }
                else
                {
                    _Uow.GetRepository<Usuario>().Update(user);

                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
            
        }

        public void Dispose()
        {
            _Uow.GetRepository<Usuario>().Dispose();
        }

        
    }
}
