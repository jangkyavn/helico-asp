using Data.Models;
using System;

namespace Service.ViewModels
{
    public class RoleViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Position { get; set; }
    }
}
