using AutoMapper;

using IntegraCliente.Dto;
using IntegraCliente.Model;

namespace IntegraCliente.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteCreateDto, Cliente>();
        }
    }
}
