using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class AboutUs : AuditableEntity
    {
        public string Id { get; set; }

        public List<AboutUsTranslation> AboutUsTranslations { get; set; }
    }
}
