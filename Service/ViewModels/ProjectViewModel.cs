using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }

        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public string CategoryName { get; set; }

        public ProjectCategoryViewModel ProjectCategory { get; set; }

        public List<ProjectTranslationViewModel> ProjectTranslations { get; set; }
    }
}
