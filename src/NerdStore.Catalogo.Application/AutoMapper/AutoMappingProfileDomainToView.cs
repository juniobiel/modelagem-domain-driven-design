using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class AutoMappingProfileDomainToView : Profile
    {
        public AutoMappingProfileDomainToView()
        {
            CreateMap<Categoria, CategoriaViewModel>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.Altura, o => o.MapFrom(v => v.Dimensoes.Altura))
                .ForMember(d => d.Largura, o => o.MapFrom(v => v.Dimensoes.Largura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(v => v.Dimensoes.Profundidade));
        }
    }
}
