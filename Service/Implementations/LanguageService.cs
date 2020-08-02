using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LanguageService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<LanguageViewModel>> GetAllAsync()
        {
            List<LanguageViewModel> result = await _dataContext.Languages
               .OrderBy(x => x.IsDefault)
               .ThenBy(x => x.Id)
               .ProjectTo<LanguageViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync();

            return result;
        }
    }
}
