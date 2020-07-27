using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Product : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsTypical { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
