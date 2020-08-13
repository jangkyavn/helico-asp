using Service.Helpers;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryViewModel> GetByIdAsync(string id);
        Task<List<ProductCategoryViewModel>> GetAllAsync();
        Task<PagedList<ProductCategoryViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProductCategoryViewModel> CreateAsync(ProductCategoryViewModel productCategoryVM);
        Task UpdateAsync(ProductCategoryViewModel productCategoryVM);
        Task ChangePositionAsync(List<ProductCategoryViewModel> listVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProductCategoryViewModel productCategoryVM);
        Task<bool> AnyAsync(string id);
    }
}
