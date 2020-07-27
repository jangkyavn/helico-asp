using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Language : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }

        public List<ProductCategoryTranslation> ProductCategoryTranslations { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<ProjectCategoryTranslation> ProjectCategoryTranslations { get; set; }
        public List<ProjectTranslation> ProjectTranslations { get; set; }
        public List<AboutUsTranslation> AboutUsTranslations { get; set; }
    }
}
