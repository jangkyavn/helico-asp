using Data.Models;

namespace Data.Entities
{
    public class ProjectTranslation : AuditableEntity
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

        public Project Project { get; set; }
        public Language Language { get; set; }
    }
}
