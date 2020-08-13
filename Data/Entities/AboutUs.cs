using Data.Models;

namespace Data.Entities
{
    public class AboutUs : AuditableEntity
    {
        public string Id { get; set; }
        public string Content_VN { get; set; }
        public string Content_EN { get; set; }
    }
}
