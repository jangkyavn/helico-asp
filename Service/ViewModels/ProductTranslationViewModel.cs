using Data.Models;

namespace Service.ViewModels
{
    public class ProductTranslationViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string Specification { get; set; }

        public ProductViewModel Product { get; set; }
        public LanguageViewModel Language { get; set; }
    }
}
