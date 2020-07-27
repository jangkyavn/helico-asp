using Data.Models;

namespace Data.Entities
{
    public class ProductTranslation : AuditableEntity
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Specification { get; set; }

        public Product Product { get; set; }
        public Language Language { get; set; }
    }
}
