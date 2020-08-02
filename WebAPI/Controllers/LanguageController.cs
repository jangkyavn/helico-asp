using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<LanguageViewModel> data = await _languageService.GetAllAsync();
            return Ok(data);
        }
    }
}
