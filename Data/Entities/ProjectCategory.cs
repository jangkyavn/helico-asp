using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class ProjectCategory : AuditableEntity
    {
        public string Id { get; set; }
        public int Position { get; set; }

        public List<ProjectCategoryTranslation> ProjectCategoryTranslations { get; set; }
        public List<Project> Projects { get; set; }
    }
}
