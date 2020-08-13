using Service.Helpers;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProjectCategoryService
    {
        Task<ProjectCategoryViewModel> GetByIdAsync(string id);
        Task<List<ProjectCategoryViewModel>> GetAllAsync();
        Task<PagedList<ProjectCategoryViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProjectCategoryViewModel> CreateAsync(ProjectCategoryViewModel projectCategoryVM);
        Task UpdateAsync(ProjectCategoryViewModel projectCategoryVM);
        Task ChangePositionAsync(List<ProjectCategoryViewModel> listVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProjectCategoryViewModel projectCategoryVM);
        Task<bool> AnyAsync(string id);
    }
}
