using Service.ViewModels;
using System.Collections.Generic;

namespace WebMVC.Models
{
    public class DetailViewModel
    {
        public ProjectViewModel Detail { get; set; }
        public List<ProjectViewModel> RelatedBlogs { get; set; }
        public List<ProjectViewModel> PopularBlogs { get; set; }
    }
}
