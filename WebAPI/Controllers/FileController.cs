using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.IO;

namespace WebAPI.Controllers
{
    public class FileController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("GetFile")]
        public IActionResult GetFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return BadRequest();
            }

            string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, path);
            return PhysicalFile(fullPath, MimeTypes.GetMimeType(fullPath), Path.GetFileName(fullPath));
        }
    }
}
