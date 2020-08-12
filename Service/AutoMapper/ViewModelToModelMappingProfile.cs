using AutoMapper;
using Data.Entities;
using Service.ViewModels;

namespace Service.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<AboutUsTranslationViewModel, AboutUsTranslation>();
            CreateMap<AboutUsViewModel, AboutUs>();
            CreateMap<ContactViewModel, Contact>();
            CreateMap<DiaryViewModel, Diary>();
            CreateMap<LanguageViewModel, Language>();
            CreateMap<NotificationViewModel, Notification>();
            CreateMap<ProductCategoryTranslationViewModel, ProductCategoryTranslation>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();
            CreateMap<ProductImageViewModel, ProductImage>();
            CreateMap<ProductTranslationViewModel, ProductTranslation>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProjectCategoryTranslationViewModel, ProjectCategoryTranslation>();
            CreateMap<ProjectCategoryViewModel, ProjectCategory>();
            CreateMap<ProjectTranslationViewModel, ProjectTranslation>();
            CreateMap<ProjectViewModel, Project>();
            CreateMap<SlideViewModel, Slide>();
            CreateMap<RoleViewModel, Role>();
            CreateMap<UserViewModel, User>();
        }
    }
}
