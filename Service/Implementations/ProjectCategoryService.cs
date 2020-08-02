using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ManualMapper;
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

            projectCategory.ProjectCategoryTranslations.Add(new ProjectCategoryTranslation
            {
                LanguageId = projectCategoryVM.LanguageId,
                Name = projectCategoryVM.Name,
                SeoPageTitle = projectCategoryVM.SeoPageTitle,
                SeoAlias = projectCategoryVM.SeoAlias,
                SeoKeywords = projectCategoryVM.SeoKeywords,
                SeoDescription = projectCategoryVM.SeoDescription
            });

            List<Language> otherLanguages = await _dataContext.Languages
                .Where(x => x.Id != projectCategoryVM.LanguageId)
                .ToListAsync();

            foreach (Language item in otherLanguages)
            {
                projectCategory.ProjectCategoryTranslations.Add(new ProjectCategoryTranslation
                {
                    LanguageId = item.Id,
                    Name = projectCategoryVM.Name,
                    SeoPageTitle = projectCategoryVM.SeoPageTitle,
                    SeoAlias = projectCategoryVM.SeoAlias,
                    SeoKeywords = projectCategoryVM.SeoKeywords,
                    SeoDescription = projectCategoryVM.SeoDescription
                });
            }

            await _dataContext.ProjectCategories.AddAsync(projectCategory);
            await _dataContext.SaveChangesAsync();
            ProjectCategoryViewModel result = projectCategoryVM.Mapper(projectCategory);
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

        public async Task<List<ProjectCategoryViewModel>> GetAllAsync(string languageId)
        {
            IQueryable<ProjectCategoryViewModel> query = from pc in _dataContext.ProjectCategories
                                                         join pct in _dataContext.ProjectCategoryTranslations
                                                         on pc.Id equals pct.ProjectCategoryId
                                                         where pct.LanguageId == languageId
                                                         orderby pc.Position
                                                         select new ProjectCategoryViewModel
                                                         {
                                                             Id = pc.Id,
                                                             Name = pct.Name
                                                         };

            List<ProjectCategoryViewModel> result = await query.ToListAsync();
            return result;
        }

        public async Task<PagedList<ProjectCategoryViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ProjectCategoryViewModel> query = from pc in _dataContext.ProjectCategories
                                                         join pct in _dataContext.ProjectCategoryTranslations
                                                         on pc.Id equals pct.ProjectCategoryId
                                                         where pct.LanguageId == @params.LanguageId
                                                         orderby pc.Position
                                                         select new ProjectCategoryViewModel
                                                         {
                                                             Id = pc.Id,
                                                             Position = pc.Position,
                                                             Name = pct.Name,
                                                             SeoPageTitle = pct.SeoPageTitle,
                                                             SeoAlias = pct.SeoAlias,
                                                             SeoKeywords = pct.SeoKeywords,
                                                             SeoDescription = pct.SeoDescription
                                                         };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.Name.ToUpper().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(@params.SortValue))
            {
                switch (@params.SortKey)
                {
                    case "name":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Name);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Name);
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

        public async Task<ProjectCategoryViewModel> GetByIdAsync(string id, string languageId)
        {
            ProjectCategoryViewModel result = await (from pc in _dataContext.ProjectCategories
                                                     join pct in _dataContext.ProjectCategoryTranslations
                                                     on pc.Id equals pct.ProjectCategoryId
                                                     where pc.Id == id && pct.LanguageId == languageId
                                                     select new ProjectCategoryViewModel
                                                     {
                                                         Id = pc.Id,
                                                         Position = pc.Position,
                                                         Name = pct.Name,
                                                         SeoPageTitle = pct.SeoPageTitle,
                                                         SeoAlias = pct.SeoAlias,
                                                         SeoKeywords = pct.SeoKeywords,
                                                         SeoDescription = pct.SeoDescription,
                                                         LanguageId = pct.LanguageId,
                                                         CreatedBy = pc.CreatedBy,
                                                         CreatedDate = pc.CreatedDate,
                                                         Status = pc.Status
                                                     }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProjectCategoryViewModel projectCategoryVM)
        {
            ProjectCategoryTranslation projectCategoryTrans = await _dataContext.ProjectCategoryTranslations
                .FirstOrDefaultAsync(x => x.ProjectCategoryId == projectCategoryVM.Id && x.LanguageId == projectCategoryVM.LanguageId);

            projectCategoryTrans.Name = projectCategoryVM.Name;
            projectCategoryTrans.SeoPageTitle = projectCategoryVM.SeoPageTitle;
            projectCategoryTrans.SeoAlias = projectCategoryVM.SeoAlias;
            projectCategoryTrans.SeoKeywords = projectCategoryVM.SeoKeywords;
            projectCategoryTrans.SeoDescription = projectCategoryVM.SeoDescription;
            await _dataContext.SaveChangesAsync();
        }
    }
}
