using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProductCategoryViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public int Position { get; set; }

        public string Name { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public List<ProductViewModel> Products { get; set; }
        public List<ProductCategoryTranslationViewModel> ProductCategoryTranslations { get; set; }
    }
}
