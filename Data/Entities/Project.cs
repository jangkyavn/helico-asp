using Data.Models;

namespace Data.Entities
{
    public class Project : AuditableEntity
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

        public ProjectCategory ProjectCategory { get; set; }
    }
}
