using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Detail(int? id)
        {
            //var detail = new DetailViewModel();
            //ViewData["BodyClass"] = "single_post_page";

            //if (id == null)
            //{
            //    return new BadRequestResult();
            //}

            //var viewModel = await _blogService.GetByIdAsync(id.Value);
            //detail.Blog = viewModel;
            //detail.RelatedBlogs = await _blogService.GetReatedBlogsAsync(id.Value, 4);
            //detail.Tags = await _blogService.GetTagsByBlogIdAsync(id.Value);

            return View();
        }
    }
}
