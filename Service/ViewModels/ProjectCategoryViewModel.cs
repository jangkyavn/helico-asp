using Data.Models;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectCategoryViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Name_VN { get; set; }
        public string Name_EN { get; set; }
        public int? Position { get; set; }

        public List<ProjectViewModel> Projects { get; set; }
    }
}
