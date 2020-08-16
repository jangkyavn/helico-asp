using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Interfaces;
using Service.ViewModels;
using System.Threading.Tasks;
using WebAPI.Extentions;

namespace WebAPI.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PagingParams pagingParams)
        {
            PagedList<ContactViewModel> paged = await _contactService.GetAllPagingAsync(pagingParams);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(paged.Items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            ContactViewModel data = await _contactService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contactVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ContactViewModel result = await _contactService.CreateAsync(contactVM);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            bool check = await _contactService.AnyAsync(id);
            if (check == false)
            {
                return NotFound();
            }

            await _contactService.DeleteAsync(id);
            return Ok(true);
        }
    }
}
