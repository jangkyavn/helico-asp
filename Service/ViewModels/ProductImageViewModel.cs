using Data.Models;

namespace Service.ViewModels
{
    public class ProductImageViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ProductId { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
