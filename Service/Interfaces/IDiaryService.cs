using Service.Helpers;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDiaryService
    {
        Task<DiaryViewModel> GetByIdAsync(string id);
        Task<PagedList<DiaryViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<DiaryViewModel> CreateAsync(DiaryViewModel diaryVM);
    }
}
