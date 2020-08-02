using Data.Models;

namespace Service.ViewModels
{
    public class ProjectTranslationViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public ProjectViewModel Project { get; set; }
        public LanguageViewModel Language { get; set; }
    }
}
