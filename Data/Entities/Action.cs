using Data.Models;
using System.Collections.Generic;

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
