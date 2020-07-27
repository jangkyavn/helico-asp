using Service.Helpers;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetByIdAsync(string id);
        Task<UserViewModel> GetByUserNameAsync(string userName);
        Task<List<UserViewModel>> GetAllAsync();
        Task<List<UserViewModel>> GetAllExceptMySelfAsync(string id);
        Task<PagedList<UserViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<UserViewModel> CreateAsync(UserAddViewModel userVM);
        Task<bool> ChangeStatusAsync(string id);
        Task UpdateAsync(UserViewModel userVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(UserViewModel userVM);
        List<EnumModel> GetGenders();
    }
}
