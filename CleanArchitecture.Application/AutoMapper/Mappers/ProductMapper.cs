using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductBasicViewModel, Product>()
                .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => DateTime.Now));

            CreateMap<ProductFullViewModel, Product>()
                .ForMember(x => x.IdProduct, y => y.MapFrom(z => z.IdProduct))
                .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => DateTime.Now));

            CreateMap<Product, ProductFullViewModel>()
                .ForMember(x => x.IdProduct, y => y.MapFrom(z => z.IdProduct))
                .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => z.RegistrationDate));
        }
    }
}
