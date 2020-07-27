using Service.Helpers;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        Task<RoleViewModel> GetByIdAsync(string id);
        Task<RoleViewModel> GetByNameAsync(string name);
        Task<List<RoleViewModel>> GetAllAsync();
        Task<PagedList<RoleViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<RoleViewModel> CreateAsync(RoleViewModel roleVM);
        Task UpdateAsync(RoleViewModel roleVM);
        Task ChangePositionAsync(List<RoleViewModel> listVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(RoleViewModel roleVM);
    }
}
