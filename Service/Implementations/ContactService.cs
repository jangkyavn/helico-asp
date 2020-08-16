using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ContactService(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> AnyAsync(string id)
        {
            bool result = await _dataContext.Contacts.AnyAsync(x => x.Id == id);
            return result;
        }

        public async Task<ContactViewModel> CreateAsync(ContactViewModel contactVM)
        {
            Contact contact = _mapper.Map<Contact>(contactVM);
            await _dataContext.Contacts.AddAsync(contact);
            await _dataContext.SaveChangesAsync();
            ContactViewModel result = _mapper.Map<ContactViewModel>(contact);
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            Contact contact = await _dataContext
                .Contacts.FirstOrDefaultAsync(x => x.Id == id);

            _dataContext.Contacts.Remove(contact);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContactViewModel contactVM)
        {
            await DeleteAsync(contactVM.Id);
        }

        public async Task<PagedList<ContactViewModel>> GetAllPagingAsync(PagingParams @params)
        {
            IQueryable<ContactViewModel> query = _dataContext.Contacts
                .ProjectTo<ContactViewModel>(_mapper.ConfigurationProvider);

            if (!string.IsNullOrEmpty(@params.Keyword))
            {
                string keyword = @params.Keyword.ToUpper().ToTrim();

                query = query.Where(x => x.FullName.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.FullName.ToUpper().Contains(keyword) ||
                                        x.Email.ToUpper().Contains(keyword) ||
                                        x.Phone.ToUpper().Contains(keyword) ||
                                        x.Address.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.Address.ToUpper().Contains(keyword) ||
                                        x.Content.ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        x.Content.ToUpper().Contains(keyword));
            }

            if (@params.PageSize == -1)
            {
                @params.PageSize = await query.CountAsync();
            }

            return await PagedList<ContactViewModel>
                .CreateAsync(query, @params.PageNumber, @params.PageSize);
        }

        public async Task<ContactViewModel> GetByIdAsync(string id)
        {
            Contact contact = await _dataContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            ContactViewModel result = _mapper.Map<ContactViewModel>(contact);
            return result;
        }
    }
}
