using AutoMapper;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.AutoMapper.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryBasicViewModel, Category>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => DateTime.Now));

            CreateMap<CategoryFullViewModel, Category>()
                .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => DateTime.Now));

            CreateMap<Category, CategoryFullViewModel>()
                .ForMember(x => x.IdCategory, y => y.MapFrom(z => z.IdCategory))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.RegistrationDate, y => y.MapFrom(z => z.RegistrationDate));


        }
    }
}
