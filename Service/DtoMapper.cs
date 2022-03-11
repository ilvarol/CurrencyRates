using AutoMapper;
using Core.Models.Dto;
using Core.Models.Entities;

namespace Service
{
    class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<AppUser, User>().ReverseMap();

            CreateMap<CurrencyRate, CurrencyRatesDto>().ReverseMap();
        }
    }
}