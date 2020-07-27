using Data.Enums;
using Data.Models;

namespace Service.ViewModels
{
    public class NotificationViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string ObjectId { get; set; }
        public string Content { get; set; }
        public bool? Read { get; set; }
        public bool? View { get; set; }
        public NotificationType Type { get; set; }

        public string SenderName { get; set; }
    }
}
