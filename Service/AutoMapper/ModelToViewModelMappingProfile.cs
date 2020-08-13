using AutoMapper;
using Data.Entities;
using Service.ViewModels;

namespace Service.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<AboutUs, AboutUsViewModel>();
            CreateMap<Contact, ContactViewModel>();
            CreateMap<Diary, DiaryViewModel>();
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProjectCategory, ProjectCategoryViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Role, RoleViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
