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
        private readonly IProductService _productService;

        public HomeController(IProjectService projectService, IProductService productService)
        {
            _projectService = projectService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";

            var homeVm = new HomeViewModel();
            homeVm.HomeSlides = await _projectService.GetSlidersAsync();
            homeVm.LatestProjects = await _projectService.GetAllAsync(4);
            homeVm.HightlightProducts = await _productService.GetAllAsync(4);
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
