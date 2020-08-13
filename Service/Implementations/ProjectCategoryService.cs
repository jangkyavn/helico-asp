using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProjectCategoryService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.ProjectCategories.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task ChangePositionAsync(List<ProjectCategoryViewModel> listVM)
        {
            int count = 1;
            foreach (ProjectCategoryViewModel item in listVM)
            {
                ProjectCategory projectCategory = await _dataContext.ProjectCategories
                    .FirstOrDefaultAsync(x => x.Id == item.Id);
                projectCategory.Position = count;
                count += 1;
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ProjectCategoryViewModel> CreateAsync(ProjectCategoryViewModel projectCategoryVM)
        {
            ProjectCategory projectCategory = _mapper.Map<ProjectCategory>(projectCategoryVM);

            if (_dataContext.ProjectCategories.Any())
            {
                int? maxPosition = await _dataContext.ProjectCategories.MaxAsync(x => x.Position);
                projectCategory.Position = maxPosition + 1;
            }
            else
            {
                projectCategory.Position = 1;
            }

            await _dataContext.ProjectCategories.AddAsync(projectCategory);
            await _dataContext.SaveChangesAsync();
            ProjectCategoryViewModel result = _mapper.Map<ProjectCategoryViewModel>(projectCategory);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            ProjectCategory projectCategory = await _dataContext
                .ProjectCategories.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.ProjectCategories.Remove(projectCategory);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProjectCategoryViewModel projectCategoryVM)
        {
            await DeleteAsync(projectCategoryVM.Id);
        }

        public async Task<List<ProjectCategoryViewModel>> GetAllAsync()
        {
            IQueryable<ProjectCategoryViewModel> query = from pc in _dataContext.ProjectCategories
                                                         orderby pc.Position
                                                         select new ProjectCategoryViewModel
                                                         {
                                                             Id = pc.Id,
                                                             Name_VN = pc.Name_VN,
                                                             Name_EN = pc.Name_EN
                                                         };

            List<ProjectCategoryViewModel> result = await query.ToListAsync();
            return result;
        }

        public async Task<PagedList<ProjectCategoryViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ProjectCategoryViewModel> query = from pc in _dataContext.ProjectCategories
                                                         orderby pc.Position
                                                         select new ProjectCategoryViewModel
                                                         {
                                                             Id = pc.Id,
                                                             Position = pc.Position,
                                                             Name_VN = pc.Name_VN,
                                                             Name_EN = pc.Name_EN
                                                         };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.Name_VN.ToUpper().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "name":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Name_VN);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Name_VN);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (@params.PageSize == -1)
            {
                @params.PageSize = await query.CountAsync();
            }

            return await PagedList<ProjectCategoryViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<ProjectCategoryViewModel> GetByIdAsync(string id)
        {
            ProjectCategoryViewModel result = await (from pc in _dataContext.ProjectCategories
                                                     where pc.Id == id
                                                     select new ProjectCategoryViewModel
                                                     {
                                                         Id = pc.Id,
                                                         Position = pc.Position,
                                                         Name_VN = pc.Name_VN,
                                                         Name_EN = pc.Name_EN,
                                                         CreatedBy = pc.CreatedBy,
                                                         CreatedDate = pc.CreatedDate,
                                                         Status = pc.Status
                                                     }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProjectCategoryViewModel projectCategoryVM)
        {
            ProjectCategory projectCategory = _mapper.Map<ProjectCategory>(projectCategoryVM);
            _dataContext.ProjectCategories.Update(projectCategory);
            await _dataContext.SaveChangesAsync();
        }
    }
}
