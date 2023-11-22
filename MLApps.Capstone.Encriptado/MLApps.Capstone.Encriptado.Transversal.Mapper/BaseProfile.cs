using AutoMapper;
using MLApps.Capstone.Encriptado.Application.DTO;
using MLApps.Capstone.Encriptado.Domain.Entity;

namespace MLApps.Capstone.Encriptado.Transversal.Mapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<RequestDomain, RequestApplication>().ReverseMap();
            CreateMap(typeof(RequestDomain<>), typeof(RequestApplication<>))
                    .IncludeAllDerived()
                    .ReverseMap();

            CreateMap<ResponseDomain, ResponseApplication>().ReverseMap();
            CreateMap(typeof(ResponseDomain<>), typeof(ResponseApplication<>))
                    .IncludeAllDerived()
                    .ReverseMap();
        }
    }
}
