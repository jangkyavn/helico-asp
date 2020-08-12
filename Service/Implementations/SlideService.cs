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
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SlideService : ISlideService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SlideService(
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
            bool result = await _dataContext.Slides.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task ChangePositionAsync(List<SlideViewModel> listVM)
        {
            int count = 1;
            foreach (SlideViewModel item in listVM)
            {
                Slide slide = await _dataContext.Slides
                    .FirstOrDefaultAsync(x => x.Id == item.Id);
                slide.Position = count;
                count += 1;
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task<SlideViewModel> CreateAsync(SlideViewModel slideVM)
        {
            Slide slide = _mapper.Map<Slide>(slideVM);

            if (await _dataContext.Slides.AnyAsync())
            {
                int? maxPosition = await _dataContext.Slides.MaxAsync(x => x.Position);
                slide.Position = maxPosition + 1;
            }
            else
            {
                slide.Position = 1;
            }

            await _dataContext.Slides.AddAsync(slide);
            await _dataContext.SaveChangesAsync();
            SlideViewModel result = _mapper.Map<SlideViewModel>(slide);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Slide slide = await _dataContext.Slides
                .FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.Slides.Remove(slide);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SlideViewModel slideVM)
        {
            await DeleteAsync(slideVM.Id);
        }

        public async Task<List<SlideViewModel>> GetAllAsync()
        {
            List<SlideViewModel> result = await (from s in _dataContext.Slides
                                                 where s.Status == true
                                                 select new SlideViewModel
                                                 {
                                                     Id = s.Id,
                                                     Title_VN = s.Title_VN,
                                                     Title_EN = s.Title_EN,
                                                     Description_VN = s.Description_VN,
                                                     Description_EN = s.Description_EN,
                                                     Image = s.Image,
                                                     ImageBase64 = s.Image.ConvertBase64(_hostingEnvironment, Constants.SlideImagePath),
                                                     ImageName = s.Image.GetOriginalImageName(),
                                                     Url_VN = s.Url_VN,
                                                     Url_EN = s.Url_EN,
                                                 }).ToListAsync();

            return result;
        }

        public async Task<SlideViewModel> GetByIdAsync(string id)
        {
            SlideViewModel result = await (from s in _dataContext.Slides
                                           where s.Id == id
                                           select new SlideViewModel
                                           {
                                               Id = s.Id,
                                               Title_VN = s.Title_VN,
                                               Title_EN = s.Title_EN,
                                               Description_VN = s.Description_VN,
                                               Description_EN = s.Description_EN,
                                               Image = s.Image,
                                               ImageBase64 = s.Image.ConvertBase64(_hostingEnvironment, Constants.SlideImagePath),
                                               ImageName = s.Image.GetOriginalImageName(),
                                               Url_VN = s.Url_VN,
                                               Url_EN = s.Url_EN,
                                               CreatedBy = s.CreatedBy,
                                               CreatedDate = s.CreatedDate,
                                               Status = s.Status
                                           }).FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateAsync(SlideViewModel slideVM)
        {
            Slide slide = _mapper.Map<Slide>(slideVM);
            _dataContext.Slides.Update(slide);
            await _dataContext.SaveChangesAsync();
        }
    }
}
