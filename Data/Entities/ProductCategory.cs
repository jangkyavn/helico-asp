using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public string Id { get; set; }
        public int Position { get; set; }

        public List<Product> Products { get; set; }
        public List<ProductCategoryTranslation> ProductCategoryTranslations { get; set; }
    }
}
