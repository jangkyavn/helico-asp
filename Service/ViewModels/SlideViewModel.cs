using Data.Models;

namespace Service.ViewModels
{
    public class SlideViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Title_VN { get; set; }
        public string Title_EN { get; set; }
        public string Description_VN { get; set; }
        public string Description_EN { get; set; }
        public string Image { get; set; }
        public string Url_VN { get; set; }
        public string Url_EN { get; set; }
        public int? Position { get; set; }

        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }
    }
}
