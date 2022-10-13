using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using ClassLibrary1;
using CRB.DA.DTO;
using CRB.DA.Models;

namespace CRB.BL.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Currency, CurrencyDTO>()
                .ForMember(dest => dest.Name, x => x.MapFrom(src => src.CurrencyData.Name))
                .ForMember(dest => dest.NumericCode, x => x.MapFrom(src => src.CurrencyData.NumericCode))
                .ForMember(dest => dest.AlphaCode, x => x.MapFrom(src => src.CurrencyData.AlphaCode))
                .ForMember(dest => dest.Price, x => x.MapFrom(src => src.Price))
                .ForMember(dest => dest.Scale, x => x.MapFrom(src => src.Scale))
                .ForMember(dest => dest.Date, x => x.MapFrom(src => src.Date)).ReverseMap();

            CreateMap<Metall, MetallDTO>().ReverseMap();

            CreateMap<RatesOnDateResponse, CurrencyRate>()
                .ForMember(dest => dest.Date, x => x.MapFrom(src => src.Date))
                .ForMember(dest => dest.Rates, x => x.MapFrom(src => src.Rates));

            CreateMap<MetalsOnDateResponse, MetallRate>()
                .ForMember(dest => dest.Date, x => x.MapFrom(src => src.Date))
                .ForMember(dest => dest.Rates, x => x.MapFrom(src => src.Prices));

            CreateMap<RateResponse, Currency>()
                .ForMember(dest => dest.CurrencyData, x => x.MapFrom(src => src.Currency)).ReverseMap();

            CreateMap<CurrencyResponse, CurrencyData>()
                .ForMember(dest => dest.AlphaCode, x => x.MapFrom(src => src.AlphaCode))
                .ForMember(dest => dest.NumericCode, x => x.MapFrom(src => src.NumericCode))
                .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Name));

            CreateMap<MetalResponse, Metall>()
                .ForMember(dest => dest.Name, x => x.MapFrom(src => src.Name))
                .ForMember(dest => dest.AlphaCode, x => x.MapFrom(src => src.AlphaCode))
                .ForMember(dest => dest.Price, x => x.MapFrom(src => src.Price));

        }
        
    }
}