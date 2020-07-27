using Data.Interfaces;
using System;

namespace Data.Models
{
    public class AuditableEntity : IAuditableEntity
    {
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }
    }
}
