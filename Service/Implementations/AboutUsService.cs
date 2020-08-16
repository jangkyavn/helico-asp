using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class AboutUsService : IAboutUsService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public AboutUsService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.AboutUs.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<AboutUsViewModel> CreateAsync(AboutUsViewModel aboutUsVM)
        {
            AboutUs aboutUs = _mapper.Map<AboutUs>(aboutUsVM);
            await _dataContext.AboutUs.AddAsync(aboutUs);
            await _dataContext.SaveChangesAsync();
            AboutUsViewModel result = _mapper.Map<AboutUsViewModel>(aboutUs);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            AboutUs aboutUs = await _dataContext
                .AboutUs.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.AboutUs.Remove(aboutUs);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(AboutUsViewModel aboutUsVM)
        {
            await DeleteAsync(aboutUsVM.Id);
        }

        public async Task<List<AboutUsViewModel>> GetAllAsync()
        {
            List<AboutUsViewModel> result = await _dataContext.AboutUs
                .ProjectTo<AboutUsViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

        public async Task<AboutUsViewModel> GetByIdAsync(string id)
        {
            AboutUsViewModel result = await _dataContext.AboutUs
                .ProjectTo<AboutUsViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task UpdateAsync(AboutUsViewModel aboutUsVM)
        {
            AboutUs aboutUs = _mapper.Map<AboutUs>(aboutUsVM);
            _dataContext.AboutUs.Update(aboutUs);
            await _dataContext.SaveChangesAsync();
        }
    }
}
