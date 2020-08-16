using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.IO;
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
            await _dataContext.Projects.AddAsync(project);
            await _dataContext.SaveChangesAsync();
            ProjectViewModel result = _mapper.Map<ProjectViewModel>(project);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Project project = await _dataContext
                .Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(project.Image))
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, Constants.ProjectImagePath + project.Image);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
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
                                                 join pc in _dataContext.ProjectCategories on p.CategoryId equals pc.Id
                                                 join u in _dataContext.Users on p.CreatedBy.ToString() equals u.Id into tmpUsers
                                                 from u in tmpUsers.DefaultIfEmpty()
                                                 orderby p.CreatedDate descending
                                                 select new ProjectViewModel
                                                 {
                                                     Id = p.Id,
                                                     Image = p.Image,
                                                     ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProjectImagePath),
                                                     Name_VN = p.Name_VN ?? string.Empty,
                                                     Name_EN = p.Name_EN ?? string.Empty,
                                                     IsHighlight = p.IsHighlight,
                                                     SelectedAsSlider = p.SelectedAsSlider,
                                                     Content_VN = p.Content_VN ?? string.Empty,
                                                     Content_EN = p.Content_EN ?? string.Empty,
                                                     CategoryName_VN = pc.Name_VN ?? string.Empty,
                                                     CategoryName_EN = pc.Name_EN ?? string.Empty,
                                                     Status = p.Status,
                                                     CreatedByName = u.UserName
                                                 };

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.Name_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.Name_VN.ToUpper().Contains(keyword) ||
                                                x.CategoryName_VN.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                                x.CategoryName_VN.ToUpper().Contains(keyword));
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
                    case "categoryName":
                        if (@params.SortValue == "ascend")
                        {
                            query = query.OrderBy(x => x.CategoryName_VN);
                        }
                        else
                        {
                            query = query.OrderByDescending(x => x.CategoryName_VN);
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

        public async Task<ProjectViewModel> GetByIdAsync(string id)
        {
            ProjectViewModel result = await (from p in _dataContext.Projects
                                             where p.Id == id
                                             select new ProjectViewModel
                                             {
                                                 Id = p.Id,
                                                 CategoryId = p.CategoryId,
                                                 Image = p.Image,
                                                 ImageBase64 = p.Image.ConvertBase64(_hostingEnvironment, Constants.ProjectImagePath),
                                                 ImageName = p.Image.GetOriginalImageName(),
                                                 Name_VN = p.Name_VN,
                                                 Name_EN = p.Name_EN,
                                                 IsHighlight = p.IsHighlight,
                                                 SelectedAsSlider = p.SelectedAsSlider,
                                                 Content_VN = p.Content_VN,
                                                 Content_EN = p.Content_EN,
                                                 CreatedBy = p.CreatedBy,
                                                 CreatedDate = p.CreatedDate,
                                                 Status = p.Status
                                             }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(ProjectViewModel projectVM)
        {
            Project project = _mapper.Map<Project>(projectVM);
            _dataContext.Projects.Update(project);
            await _dataContext.SaveChangesAsync();
        }
    }
}
