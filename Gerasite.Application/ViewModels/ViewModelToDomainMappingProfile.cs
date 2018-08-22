using AutoMapper;
using Gerasite.Dominio.Entidades;

namespace Gerasite.Application.ViewModels
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() => CreateMap<UsuarioViewModel, Usuario>();
    }
}
