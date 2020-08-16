using Service.Helpers;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAboutUsService
    {
        Task<AboutUsViewModel> GetByIdAsync(string id);
        Task<List<AboutUsViewModel>> GetAllAsync();
        Task<AboutUsViewModel> CreateAsync(AboutUsViewModel aboutUsVM);
        Task UpdateAsync(AboutUsViewModel aboutUsVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(AboutUsViewModel aboutUsVM);
        Task<bool> AnyAsync(string id);
    }
}
