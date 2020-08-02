using Service.Helpers;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProjectCategoryService
    {
        Task<ProjectCategoryViewModel> GetByIdAsync(string id, string languageId);
        Task<List<ProjectCategoryViewModel>> GetAllAsync(string languageId);
        Task<PagedList<ProjectCategoryViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProjectCategoryViewModel> CreateAsync(ProjectCategoryViewModel projectCategoryVM);
        Task UpdateAsync(ProjectCategoryViewModel projectCategoryVM);
        Task ChangePositionAsync(List<ProjectCategoryViewModel> listVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProjectCategoryViewModel projectCategoryVM);
        Task<bool> AnyAsync(string id);
    }
}
