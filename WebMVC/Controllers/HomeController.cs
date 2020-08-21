using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _projectService;

        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";

            var homeVm = new HomeViewModel();
            // homeVm.Title = _localizer["TITLE"];
            homeVm.LatestProjects = await _projectService.GetAllAsync(4);

            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
