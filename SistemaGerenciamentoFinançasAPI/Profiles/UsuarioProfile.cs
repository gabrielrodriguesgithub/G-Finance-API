using AutoMapper;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.UsuariosDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
