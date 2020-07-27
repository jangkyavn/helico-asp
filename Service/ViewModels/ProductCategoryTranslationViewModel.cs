using Data.Models;

namespace Service.ViewModels
{
    public class ProductCategoryTranslationViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string ProductCategoryId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }
        public LanguageViewModel Language { get; set; }
    }
}
