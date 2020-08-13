using Data.Entities;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DatabaseInitializer(
            DataContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Admin",
                    Description = "Quản trị viên",
                    Position = 1
                });

                await _roleManager.CreateAsync(new Role()
                {
                    Name = "Member",
                    Description = "Thành viên",
                    Position = 2
                });
            }

            if (!_userManager.Users.Any())
            {
                User user1 = new User()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    BirthDay = DateTime.Now,
                    Gender = Gender.Male,
                    Status = true
                };
                IdentityResult result1 = await _userManager.CreateAsync(user1, "123456");
                if (result1.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync("admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }

                User user2 = new User()
                {
                    UserName = "anhbh",
                    FullName = "Bùi Hoàng Anh",
                    Email = "anhbh@gmail.com",
                    BirthDay = DateTime.Now,
                    Gender = Gender.Male,
                    Status = false
                };
                IdentityResult result2 = await _userManager.CreateAsync(user2, "123456");
                if (result2.Succeeded)
                {
                    User admin = _userManager.FindByNameAsync("anhbh").Result;
                    _userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
