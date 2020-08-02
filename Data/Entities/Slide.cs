using Data.Models;

namespace Data.Entities
{
    public class Slide : AuditableEntity
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public int? Position { get; set; }
    }
}
