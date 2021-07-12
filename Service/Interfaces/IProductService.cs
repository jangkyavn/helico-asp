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
        Task<ProductViewModel> GetByIdAsync(string id);
        Task<List<ProductViewModel>> GetAllAsync(int? top = null);
        Task<PagedList<ProductViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProductViewModel> CreateAsync(ProductViewModel productVM);
        Task UpdateAsync(ProductViewModel productVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProductViewModel productVM);
        Task<bool> AnyAsync(string id);
    }
}
