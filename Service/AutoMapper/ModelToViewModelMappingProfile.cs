using AutoMapper;
using Data.Entities;
using Service.ViewModels;

namespace Service.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<AboutUsTranslation, AboutUsTranslationViewModel>();
            CreateMap<AboutUs, AboutUsViewModel>();
            CreateMap<Contact, ContactViewModel>();
            CreateMap<Diary, DiaryViewModel>();
            CreateMap<Language, LanguageViewModel>();
            CreateMap<Notification, NotificationViewModel>();
            CreateMap<ProductCategoryTranslation, ProductCategoryTranslationViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<ProductTranslation, ProductTranslationViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProjectCategoryTranslation, ProjectCategoryTranslationViewModel>();
            CreateMap<ProjectCategory, ProjectCategoryViewModel>();
            CreateMap<ProjectTranslation, ProjectTranslationViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Role, RoleViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
