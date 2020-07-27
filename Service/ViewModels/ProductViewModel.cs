using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProductViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsTypical { get; set; }

        public ProductCategoryViewModel ProductCategory { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
        public List<ProductTranslationViewModel> ProductTranslations { get; set; }
    }
}
