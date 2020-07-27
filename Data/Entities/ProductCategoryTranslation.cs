using Data.Models;

namespace Data.Entities
{
    public class ProductCategoryTranslation : AuditableEntity
    {
        public string Id { get; set; }
        public string ProductCategoryId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public Language Language { get; set; }
    }
}
