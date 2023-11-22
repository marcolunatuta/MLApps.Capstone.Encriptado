using AutoMapper;
using MLApps.Capstone.Encriptado.Application.DTO;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;

namespace MLApps.Capstone.Encriptado.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Informacion, InformacionDto>().ReverseMap();
        }
    }
}