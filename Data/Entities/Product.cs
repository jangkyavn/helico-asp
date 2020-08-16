using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Product : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name_VN { get; set; }
        public string Name_EN { get; set; }
        public string ShortDescription_VN { get; set; }
        public string ShortDescription_EN { get; set; }
        public string DetailedDescription_VN { get; set; }
        public string DetailedDescription_EN { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsHighlight { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
