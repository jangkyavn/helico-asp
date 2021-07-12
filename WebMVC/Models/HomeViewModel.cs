using Service.ViewModels;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public class HomeViewModel
    {
        public List<ProjectViewModel> HomeSlides { get; set; }
        public List<ProjectViewModel> LatestProjects { get; set; }
        public List<ProductViewModel> HightlightProducts { get; set; }
        public List<ProjectCategoryViewModel> HomeCategories { get; set; }
    }
}
