using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _dataContext;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(
            DataContext dataContext,
            RoleManager<Role> roleManager,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task ChangePositionAsync(List<RoleViewModel> listVM)
        {
            int count = 1;
            foreach (RoleViewModel item in listVM)
            {
                item.Position = count;
                await UpdateAsync(item);
                count += 1;
            }
        }

        public async Task<RoleViewModel> CreateAsync(RoleViewModel roleVM)
        {
            Role role = _mapper.Map<Role>(roleVM);

            if (_dataContext.Roles.Any())
            {
                int? maxPosition = await _dataContext.Roles.MaxAsync(x => x.Position);
                role.Position = maxPosition + 1;
            }
            else
            {
                role.Position = 1;
            }

            await _roleManager.CreateAsync(role);
            RoleViewModel result = _mapper.Map<RoleViewModel>(role);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
        }

        public async Task DeleteAsync(RoleViewModel roleVM)
        {
            await DeleteAsync(roleVM.Id);
        }

        public async Task<List<RoleViewModel>> GetAllAsync()
        {
            List<RoleViewModel> rolesVM = await _roleManager.Roles
                .OrderBy(x => x.Position)
                .ProjectTo<RoleViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return rolesVM;
        }

        public async Task<PagedList<RoleViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<RoleViewModel> query = from r in _roleManager.Roles
                                              orderby r.Position
                                              select new RoleViewModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Description = r.Description
                                              };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x =>
                                    x.Name.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                    x.Name.ToUpper().Contains(keyword) ||
                                    x.Description.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                    x.Description.ToUpper().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(@params.SearchValue))
            {
                if (@params.SearchKey == "name")
                    query = query.Where(x => x.Name == @params.SearchValue.Trim());
                if (@params.SearchKey == "description")
                    query = query.Where(x => x.Description == @params.SearchValue.Trim());
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "name":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Name);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Name);
                        }
                        break;
                    case "description":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Description);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Description);
                        }
                        break;
                    default:
                        break;
                }
            }

            return await PagedList<RoleViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<RoleViewModel> GetByIdAsync(string id)
        {
            Role role = await _dataContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            RoleViewModel result = _mapper.Map<RoleViewModel>(role);
            return result;
        }

        public async Task<RoleViewModel> GetByNameAsync(string name)
        {
            Role role = await _dataContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            RoleViewModel result = _mapper.Map<RoleViewModel>(role);
            return result;
        }

        public async Task UpdateAsync(RoleViewModel roleVM)
        {
            Role role = await _roleManager.FindByIdAsync(roleVM.Id);
            role.Name = roleVM.Name;
            role.Description = roleVM.Description;
            role.Position = roleVM.Position;
            await _roleManager.UpdateAsync(role);
        }
    }
}
