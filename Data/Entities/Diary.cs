using System;

namespace Data.Entities
{
    public class Diary
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
    }
}
