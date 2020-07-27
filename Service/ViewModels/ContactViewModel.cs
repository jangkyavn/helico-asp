using Data.Models;

namespace Service.ViewModels
{
    public class ContactViewModel : AuditableEntity
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
