using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var detail = new DetailViewModel();
            ViewData["BodyClass"] = "single_post_page";

            if (id == null)
            {
                return new BadRequestResult();
            }

            var model = await _projectService.GetByIdAsync(id);
            detail.Detail = model;
            var blogs = await _projectService.GetAllAsync(4);
            detail.RelatedBlogs = blogs.Where(x => x.Id != id).ToList();
            detail.PopularBlogs = blogs.Where(x => x.Id != id && x.IsHighlight == true).ToList();

            return View(detail);
        }
    }
}
