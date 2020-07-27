using Data.Models;

namespace Data.Entities
{
    public class ProductImage : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
