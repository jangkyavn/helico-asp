using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Action : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Position { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
