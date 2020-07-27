using Data.Entities;
using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;

namespace Service.ViewModels
{
    public class UserViewModel : AuditableEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string Configuration { get; set; }
        public string Avatar { get; set; }
        public List<Role> Roles { get; set; }
    }
}
