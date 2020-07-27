using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Role : IdentityRole<string>, IAuditableEntity
    {
        public Role()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }

        public Role(string roleName, string description) : base(roleName)
        {
            Description = description;
        }

        public string Description { get; set; }
        public int? Position { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
