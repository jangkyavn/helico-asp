﻿using Service.Helpers;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectViewModel> GetByIdAsync(string id);
        Task<List<ProjectViewModel>> GetAllAsync(int? top = null);
        Task<List<ProjectViewModel>> GetSlidersAsync();
        Task<PagedList<ProjectViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ProjectViewModel> CreateAsync(ProjectViewModel projectVM);
        Task UpdateAsync(ProjectViewModel projectVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ProjectViewModel projectVM);
        Task<bool> AnyAsync(string id);
    }
}
