using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Function : AuditableEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
