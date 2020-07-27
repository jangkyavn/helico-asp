using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Image { get; set; }

        public ProjectCategoryViewModel ProjectCategory { get; set; }

        public List<ProjectTranslationViewModel> ProjectTranslations { get; set; }
    }
}
