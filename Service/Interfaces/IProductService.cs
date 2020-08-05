using Service.Helpers;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetByIdAsync(string id, string languageId);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<PagedList<ProductViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProductViewModel> CreateAsync(ProductViewModel productVM);
        Task UpdateAsync(ProductViewModel productVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProductViewModel productVM);
        Task<bool> AnyAsync(string id);
    }
}
