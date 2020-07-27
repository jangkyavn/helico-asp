using AutoMapper;
using Data;
using Data.Entities;
using Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public UserService(
            DataContext dataContext,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<bool> ChangeStatusAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            user.Status = !user.Status;
            bool result = await _dataContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<UserViewModel> CreateAsync(UserAddViewModel userVM)
        {
            User user = _mapper.Map<User>(userVM);

            IdentityResult result = await _userManager.CreateAsync(user, userVM.Password);
            if (result.Succeeded)
            {
                if (userVM.Roles.Count() > 0)
                {
                    await _userManager.AddToRolesAsync(user, userVM.Roles.Select(x => x.Name));
                }

                UserViewModel data = _mapper.Map<UserViewModel>(user);
                return data;
            }

            return null;
        }

        public async Task DeleteAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
        }

        public async Task DeleteAsync(UserViewModel userVM)
        {
            await DeleteAsync(userVM.Id);
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            List<UserViewModel> usersVM = await GetAllQuery().ToListAsync();
            return usersVM;
        }

        public async Task<List<UserViewModel>> GetAllExceptMySelfAsync(string id)
        {
            List<UserViewModel> usersVM = await GetAllQuery()
                .Where(x => x.Id != id)
                .ToListAsync();

            return usersVM;
        }

        public async Task<PagedList<UserViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<UserViewModel> query = GetAllQuery().Where(x => x.Status == true);

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x =>
                    x.UserName.ToUpper().Contains(keyword) ||
                    x.FullName.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                    x.FullName.ToUpper().Contains(keyword) ||
                    x.Email.ToUpper().Contains(keyword) ||
                    x.PhoneNumber.ToUpper().Contains(keyword) ||
                    x.Roles.Select(y => y.Name).Any(y => y.ToUpper().Contains(keyword)));
            }

            if (!string.IsNullOrEmpty(@params.SearchValue))
            {
                if (@params.SearchKey == "userName")
                    query = query.Where(x => x.UserName == @params.SearchValue.Trim());
                if (@params.SearchKey == "fullName")
                    query = query.Where(x => x.FullName == @params.SearchValue.Trim());
                if (@params.SearchKey == "email")
                    query = query.Where(x => x.Email == @params.SearchValue.Trim());
                if (@params.SearchKey == "phoneNumber")
                    query = query.Where(x => x.PhoneNumber == @params.SearchValue.Trim());
                if (@params.SearchKey == "roles")
                    query = query.Where(x => x.Roles.Any(y => y.Equals(@params.SearchValue.Trim())));
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "userName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.UserName);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.UserName);
                        }
                        break;
                    case "fullName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.FullName);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.FullName);
                        }
                        break;
                    case "email":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Email);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Email);
                        }
                        break;
                    case "phoneNumber":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.PhoneNumber);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.PhoneNumber);
                        }
                        break;
                    default:
                        break;
                }
            }

            return await PagedList<UserViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<UserViewModel> GetByIdAsync(string id)
        {
            UserViewModel userVM = await GetAllQuery()
                .FirstOrDefaultAsync(x => x.Id == id);

            return userVM;
        }

        public async Task<UserViewModel> GetByUserNameAsync(string userName)
        {
            UserViewModel userVM = await GetAllQuery()
                .FirstOrDefaultAsync(x => x.UserName == userName);

            return userVM;
        }

        public List<EnumModel> GetGenders()
        {
            List<EnumModel> enums = ((Gender[])Enum.GetValues(typeof(Gender)))
               .Select(c => new EnumModel()
               {
                   Value = (int)c,
                   Name = c.GetDescription()
               }).ToList();
            return enums;
        }

        public async Task UpdateAsync(UserViewModel userVM)
        {
            User user = await _userManager.FindByIdAsync(userVM.Id.ToString());

            IList<string> currentRoles = await _userManager.GetRolesAsync(user);
            string[] needAddRoles = userVM.Roles.Select(x => x.Name).Except(currentRoles).ToArray();
            string[] needRemoveRoles = currentRoles.Except(userVM.Roles.Select(x => x.Name)).ToArray();

            await _userManager.AddToRolesAsync(user, needAddRoles);
            await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);

            _dataContext.Entry(user).CurrentValues.SetValues(userVM);
            await _userManager.UpdateAsync(user);
        }

        private IQueryable<UserViewModel> GetAllQuery()
        {
            IQueryable<UserViewModel> query = from u in _dataContext.Users
                                              orderby u.UserName
                                              select new UserViewModel
                                              {
                                                  Id = u.Id,
                                                  UserName = u.UserName,
                                                  Email = u.Email,
                                                  FullName = u.FullName,
                                                  PhoneNumber = u.PhoneNumber,
                                                  Status = u.Status,
                                                  Roles = (from ur in _dataContext.UserRoles
                                                           join r in _dataContext.Roles on ur.RoleId equals r.Id
                                                           where ur.UserId == u.Id
                                                           select r).ToList()
                                              };

            return query;
        }
    }
}
