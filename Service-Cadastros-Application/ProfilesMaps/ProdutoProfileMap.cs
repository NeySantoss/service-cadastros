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
    public class ProdutoProfileMap : Profile
    {
        public ProdutoProfileMap()
        {
            CreateMap<ProdutoViewModel, ProdutoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))                
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Validade, opt => opt.MapFrom(src => src.Validade))
                .ForMember(dest => dest.Data_Registro, opt => opt.MapFrom(src => src.DataRegistro))
                .ForMember(dest => dest.Data_Alteracao, opt => opt.MapFrom(src => src.DataAlteracao))
                .ForMember(dest => dest.Usuario_Registro, opt => opt.MapFrom(src => src.UsuarioRegistro))
                .ForMember(dest => dest.Usuario_Alteracao, opt => opt.MapFrom(src => src.UsuarioAlteracao))
                .ReverseMap();

            CreateMap<ResponseProdutoViewModel, ConsultaProdutoValueObject>()
                .IncludeBase<ProdutoViewModel, ProdutoDTO>()
                .ForMember(dest => dest.QtdeEstoque, opt => opt.MapFrom(src => src.QtdeEstoque))                
                .ReverseMap();

            CreateMap<ResquestProdutoViewModel, ProdutoDTO>()
                .IncludeBase<ProdutoViewModel, ProdutoDTO>()                
                .ReverseMap();

            CreateMap<RequestProdutoFiltrosViewModel, FiltrosProdutoValueObjet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.ValidadeInicio, opt => opt.MapFrom(src => src.ValidadeInicio))
                .ForMember(dest => dest.ValidadeFim, opt => opt.MapFrom(src => src.ValidadeFim))
                .ReverseMap();



        }
    }
}

