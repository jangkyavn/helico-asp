using System;

namespace Data.Interfaces
{
    public interface IAuditableEntity
    {
        Guid? CreatedBy { get; set; }
        Guid? ModifiedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        bool? Status { get; set; }
    }
}
