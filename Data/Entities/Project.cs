using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Project : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }

        public ProjectCategory ProjectCategory { get; set; }

        public List<ProjectTranslation> ProjectTranslations { get; set; }
    }
}
