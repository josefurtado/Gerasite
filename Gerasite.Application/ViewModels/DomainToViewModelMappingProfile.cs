using AutoMapper;
using Gerasite.Dominio.Entidades;

namespace Gerasite.Application.ViewModels
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() => CreateMap<Usuario, UsuarioViewModel>();
    }
}
