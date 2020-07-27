using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class DiaryService : IDiaryService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public DiaryService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<DiaryViewModel> CreateAsync(DiaryViewModel diaryVM)
        {
            Diary diary = _mapper.Map<Diary>(diaryVM);

            await _dataContext.Diaries.AddAsync(diary);
            await _dataContext.SaveChangesAsync();
            DiaryViewModel result = _mapper.Map<DiaryViewModel>(diary);
            return result;
        }

        public async Task<PagedList<DiaryViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<DiaryViewModel> query = from d in _dataContext.Diaries
                                               join u in _dataContext.Users on d.UserId equals u.Id
                                               orderby d.CreatedDate descending
                                               select new DiaryViewModel
                                               {
                                                   Id = d.Id,
                                                   UserId = u.Id,
                                                   UserName = u.UserName,
                                                   CreatedDate = d.CreatedDate,
                                                   Action = d.Action,
                                                   ActionName = d.Action.GetDescription(),
                                                   Description = d.Description,
                                                   Browser = d.Browser,
                                                   Device = d.Device
                                               };

            return await PagedList<DiaryViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<DiaryViewModel> GetByIdAsync(string id)
        {
            Diary diary = await _dataContext.Diaries
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            DiaryViewModel result = _mapper.Map<DiaryViewModel>(diary);
            return result;
        }
    }
}
