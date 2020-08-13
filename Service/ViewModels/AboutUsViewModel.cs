using Data.Models;

namespace Service.ViewModels
{
    public class AboutUsViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Content_VN { get; set; }
        public string Content_EN { get; set; }
    }
}
