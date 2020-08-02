using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILanguageService
    {
        Task<List<LanguageViewModel>> GetAllAsync();
    }
}
