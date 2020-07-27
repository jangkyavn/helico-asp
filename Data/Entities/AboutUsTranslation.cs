using Data.Models;

namespace Data.Entities
{
    public class AboutUsTranslation : AuditableEntity
    {
        public string Id { get; set; }
        public string AboutUsId { get; set; }
        public string LanguageId { get; set; }
        public string Content { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public AboutUs AboutUs { get; set; }
        public Language Language { get; set; }
    }
}
