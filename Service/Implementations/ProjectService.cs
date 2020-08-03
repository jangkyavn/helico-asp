using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
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
    public class ProjectService : IProjectService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProjectService(
            DataContext dataContext,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.Projects.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<ProjectViewModel> CreateAsync(ProjectViewModel projectVM)
        {
            Project project = _mapper.Map<Project>(projectVM);

            project.ProjectTranslations.Add(new ProjectTranslation
            {
                LanguageId = projectVM.LanguageId,
                Name = projectVM.Name,
                Description = projectVM.Description,
                Content = projectVM.Content,
                SeoPageTitle = projectVM.SeoPageTitle,
                SeoAlias = projectVM.SeoAlias,
                SeoKeywords = projectVM.SeoKeywords,
                SeoDescription = projectVM.SeoDescription
            });

            List<Language> otherLanguages = await _dataContext.Languages
                .Where(x => x.Id != projectVM.LanguageId)
                .ToListAsync();

            foreach (Language item in otherLanguages)
            {
                project.ProjectTranslations.Add(new ProjectTranslation
                {
                    LanguageId = item.Id,
                    Name = projectVM.Name,
                    Description = projectVM.Description,
                    Content = projectVM.Content,
                    SeoPageTitle = projectVM.SeoPageTitle,
                    SeoAlias = projectVM.SeoAlias,
                    SeoKeywords = projectVM.SeoKeywords,
                    SeoDescription = projectVM.SeoDescription
                });
            }

            await _dataContext.Projects.AddAsync(project);
            await _dataContext.SaveChangesAsync();
            ProjectViewModel result = projectVM.Mapper(project);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Project project = await _dataContext
                .Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(project.Image))
            {
                string filePath = _hostingEnvironment.WebRootPath + Constants.ProjectImagePath + project.Image;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _dataContext.Projects.Remove(project);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProjectViewModel projectVM)
        {
            await DeleteAsync(projectVM.Id);
        }

        public async Task<List<ProjectViewModel>> GetAllAsync()
        {
            List<ProjectViewModel> result = await _dataContext.Projects
              .OrderByDescending(x => x.CreatedDate)
              .ProjectTo<ProjectViewModel>(_mapper.ConfigurationProvider)
              .ToListAsync();

            return result;
        }

        public async Task<PagedList<ProjectViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ProjectViewModel> query = from p in _dataContext.Projects
                                                 join pt in _dataContext.ProjectTranslations
                                                 on p.Id equals pt.ProjectId
                                                 join pc in _dataContext.ProjectCategories
                                                 on p.CategoryId equals pc.Id
                                                 join pct in _dataContext.ProjectCategoryTranslations
                                                 on pc.Id equals pct.ProjectCategoryId
                                                 where pt.LanguageId == @params.LanguageId && pct.LanguageId == @params.LanguageId
                                                 orderby p.CreatedDate descending
                                                 select new ProjectViewModel
                                                 {
                                                     Id = p.Id,
                                                     Image = p.Image,
                                                     ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProjectImagePath),
                                                     Name = pt.Name,
                                                     Description = pt.Description,
                                                     Content = pt.Content,
                                                     CategoryName = pct.Name
                                                 };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.Name.ToUpper().Contains(keyword) ||
                                                x.Description.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.Description.ToUpper().Contains(keyword) ||
                                                x.CategoryName.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.CategoryName.ToUpper().Contains(keyword));
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
                    case "description":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.Description);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.Description);
                        }
                        break;
                    case "categoryName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.CategoryName);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.CategoryName);
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

            return await PagedList<ProjectViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<ProjectViewModel> GetByIdAsync(string id, string languageId)
        {
            ProjectViewModel result = await (from p in _dataContext.Projects
                                             join pt in _dataContext.ProjectTranslations
                                             on p.Id equals pt.ProjectId
                                             where p.Id == id && pt.LanguageId == languageId
                                             select new ProjectViewModel
                                             {
                                                 Id = p.Id,
                                                 CategoryId = p.CategoryId,
                                                 Image = p.Image,
                                                 ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProjectImagePath),
                                                 ImageName = p.Image.GetOriginalImageName(),
                                                 Name = pt.Name,
                                                 Description = pt.Description,
                                                 Content = pt.Content,
                                                 SeoPageTitle = pt.SeoPageTitle,
                                                 SeoAlias = pt.SeoAlias,
                                                 SeoKeywords = pt.SeoKeywords,
                                                 SeoDescription = pt.SeoDescription,
                                                 LanguageId = pt.LanguageId,
                                                 CreatedBy = p.CreatedBy,
                                                 CreatedDate = p.CreatedDate,
                                                 Status = p.Status
                                             }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProjectViewModel projectVM)
        {
            ProjectTranslation projectTrans = await _dataContext.ProjectTranslations
                .FirstOrDefaultAsync(x => x.ProjectId == projectVM.Id && x.LanguageId == projectVM.LanguageId);

            projectTrans.Name = projectVM.Name;
            projectTrans.Description = projectVM.Description;
            projectTrans.Content = projectVM.Content;
            projectTrans.SeoPageTitle = projectVM.SeoPageTitle;
            projectTrans.SeoAlias = projectVM.SeoAlias;
            projectTrans.SeoKeywords = projectVM.SeoKeywords;
            projectTrans.SeoDescription = projectVM.SeoDescription;
            await _dataContext.SaveChangesAsync();
        }
    }
}
