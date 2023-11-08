using AutoMapper;
using service_cadastros_application.ViewModels;
using service_cadastros_persistence.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_cadastros_application.ProfilesMaps
{
    public class LoginProfileMap : Profile
    {
        public LoginProfileMap()
        {
            CreateMap<LoginViewModel, LoginValueObject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.IsAtivo, opt => opt.MapFrom(src => Helper.BooleanToString(src.IsAtivo)))
                .ReverseMap();                

            CreateMap<ResponseLoginViewModel, LoginValueObject>()
                .IncludeBase<LoginViewModel, LoginValueObject>()                
                .ReverseMap();

            CreateMap<RequestFiltrosConsultaViewModel, RequestFiltrosConsultaValueObject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ReverseMap();




        }

    }
}
