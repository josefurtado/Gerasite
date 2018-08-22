using Gerasite.Application.ViewModels;
using System.Collections.Generic;

namespace Gerasite.Application.Services.Interfaces
{
    public interface IUsuarioService 
    {
        IEnumerable<UsuarioViewModel> Get();
        UsuarioViewModel Get(int id);
        void SaveOrUpdate(UsuarioViewModel entity);
        void Delete(int id);
    }
}
