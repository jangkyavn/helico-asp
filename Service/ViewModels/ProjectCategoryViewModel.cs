using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectCategoryViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public int? Position { get; set; }

        public List<ProjectCategoryTranslationViewModel> ProjectCategoryTranslations { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
    }
}
