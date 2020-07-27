using Data.Enums;
using Data.Models;

namespace Data.Entities
{
    public class Notification : AuditableEntity
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ObjectId { get; set; }
        public string Content { get; set; }
        public bool? Read { get; set; }
        public bool? View { get; set; }
        public NotificationType Type { get; set; }
    }
}
