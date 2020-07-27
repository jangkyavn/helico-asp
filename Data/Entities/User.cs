using Data.Enums;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    public class User : IdentityUser<string>, IAuditableEntity
    {
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string Configuration { get; set; }
        public string Avatar { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }
    }
}
