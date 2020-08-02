using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectCategoryViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public int? Position { get; set; }

        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public List<ProjectCategoryTranslationViewModel> ProjectCategoryTranslations { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
    }
}
