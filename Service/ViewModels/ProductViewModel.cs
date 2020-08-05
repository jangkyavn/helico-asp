using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProductViewModel : AuditableEntity
    {
        public ProductViewModel()
        {
            Price = 0;
            Quantity = 0;
            IsTypical = false;
        }

        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsTypical { get; set; }

        public string CategoryName { get; set; }
        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }

        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
        public List<ProductTranslationViewModel> ProductTranslations { get; set; }
    }
}
