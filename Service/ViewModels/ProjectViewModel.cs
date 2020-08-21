using Data.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class ProjectViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name_VN { get; set; }
        public string Name_EN { get; set; }
        public bool? IsHighlight { get; set; }
        public bool? SelectedAsSlider { get; set; }
        public string Content_VN { get; set; }
        public string Content_EN { get; set; }
        public string Image { get; set; }

        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }
        public List<IFormFile> Files { get; set; }
        public string CategoryName_VN { get; set; }
        public string CategoryName_EN { get; set; }
        public string CreatedByName { get; set; }
        public string UrlFriendly_VN { get; set; }
        public string UrlFriendly_EN { get; set; }

        public ProjectCategoryViewModel ProjectCategory { get; set; }
    }
}
