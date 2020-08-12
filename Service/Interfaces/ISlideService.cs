using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISlideService
    {
        Task<SlideViewModel> GetByIdAsync(string id);
        Task<List<SlideViewModel>> GetAllAsync();
        Task<SlideViewModel> CreateAsync(SlideViewModel slideVM);
        Task UpdateAsync(SlideViewModel slideVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(SlideViewModel slideVM);
        Task<bool> AnyAsync(string id);
        Task ChangePositionAsync(List<SlideViewModel> listVM);
    }
}
