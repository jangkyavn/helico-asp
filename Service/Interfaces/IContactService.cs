using Service.Helpers;
using Service.ViewModels;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IContactService
    {
        Task<ContactViewModel> GetByIdAsync(string id);
        Task<PagedList<ContactViewModel>> GetAllPagingAsync(PagingParams @params);
        Task<ContactViewModel> CreateAsync(ContactViewModel contactVM);
        Task DeleteAsync(string id);
        Task DeleteAsync(ContactViewModel contactVM);
        Task<bool> AnyAsync(string id);
    }
}
