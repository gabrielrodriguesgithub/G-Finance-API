using AutoMapper;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.CategoriaDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>()
                .ForMember(categoriaDto => categoriaDto.Despesas, opt => opt.MapFrom(categoria => categoria.Despesas));
        }
    }
}
