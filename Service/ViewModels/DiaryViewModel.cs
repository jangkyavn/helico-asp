using Data.Enums;
using System;

namespace Service.ViewModels
{
    public class DiaryViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }

        public string UserName { get; set; }
        public string ActionName { get; set; }
    }
}
