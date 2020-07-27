using Data.Models;

namespace Data.Entities
{
    public class Contact : AuditableEntity
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
    }
}
