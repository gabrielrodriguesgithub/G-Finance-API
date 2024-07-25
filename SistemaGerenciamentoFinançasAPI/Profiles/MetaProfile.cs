using AutoMapper;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.DespesasDto;
using SistemaGerenciamentoFinançasAPI.Data.DTOs.MetaDto;
using SistemaGerenciamentoFinançasAPI.Models;

namespace SistemaGerenciamentoFinançasAPI.Profiles
{
    public class MetaProfile : Profile
    {
        public MetaProfile()
        {
            CreateMap<CreateMetaDto, Meta>();
            CreateMap<Meta, ReadMetaDto>();
        }
      
    }
}
