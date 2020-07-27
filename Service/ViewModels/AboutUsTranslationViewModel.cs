using Data.Models;

namespace Service.ViewModels
{
    public class AboutUsTranslationViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string AboutUsId { get; set; }
        public string LanguageId { get; set; }
        public string Content { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public AboutUsViewModel AboutUs { get; set; }
        public LanguageViewModel Language { get; set; }
    }
}
