using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class LanguageViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }

        public List<ProductCategoryTranslationViewModel> ProductCategoryTranslations { get; set; }
        public List<ProductTranslationViewModel> ProductTranslations { get; set; }
        public List<ProjectCategoryTranslationViewModel> ProjectCategoryTranslations { get; set; }
        public List<ProjectTranslationViewModel> ProjectTranslations { get; set; }
        public List<AboutUsTranslationViewModel> AboutUsTranslations { get; set; }
    }
}
