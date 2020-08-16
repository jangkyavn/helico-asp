using AutoMapper;
using Data.Entities;
using Service.ViewModels;

namespace Service.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<AboutUsViewModel, AboutUs>();
            CreateMap<ContactViewModel, Contact>();
            CreateMap<DiaryViewModel, Diary>();
            CreateMap<NotificationViewModel, Notification>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductImageViewModel, ProductImage>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProjectCategoryViewModel, ProjectCategory>();
            CreateMap<ProjectViewModel, Project>();
            CreateMap<RoleViewModel, Role>();
            CreateMap<UserViewModel, User>();
        }
    }
}
