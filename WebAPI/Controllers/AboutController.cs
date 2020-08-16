using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModels;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpGet("GetAboutUs/{id}")]
        public async Task<IActionResult> GetAboutUs(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            AboutUsViewModel data = await _aboutUsService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("CreateAboutUs")]
        public async Task<IActionResult> CreateAboutUs(AboutUsViewModel aboutUsVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AboutUsViewModel result = await _aboutUsService.CreateAsync(aboutUsVM);
            return CreatedAtAction(nameof(GetAboutUs), new { id = result.Id }, result);
        }

        [HttpPut("UpdateAboutUs")]
        public async Task<IActionResult> UpdateAboutUs(AboutUsViewModel aboutUsVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(aboutUsVM.Id))
            {
                return BadRequest();
            }

            bool checkAny = await _aboutUsService.AnyAsync(aboutUsVM.Id);
            if (checkAny == false)
            {
                return NotFound();
            }

            await _aboutUsService.UpdateAsync(aboutUsVM);
            return Ok(true);
        }
    }
}
