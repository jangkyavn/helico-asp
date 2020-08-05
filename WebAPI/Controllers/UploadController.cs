using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UploadController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult UploadFile([FromForm] UploadFileParams @params)
        {
            IFormFile file = @params.File;
            if (file == null)
            {
                return new OkObjectResult(new FileResponse
                {
                    FileName = string.Empty,
                    FilePath = string.Empty
                });
            }
            else
            {
                string fileFolder = $@"\uploaded\{@params.FolderType}\{@params.FolderName}";
                string folder = _hostingEnvironment.WebRootPath + fileFolder;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (!string.IsNullOrEmpty(@params.FileName))
                {
                    string oldFilePath = Path.Combine(folder, @params.FileName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                string fileName = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');

                int lastDot = fileName.LastIndexOf('.');
                fileName = fileName.Insert(lastDot, DateTime.Now.ToString("-yyyyMMddHHmmssfff"));

                string filePath = Path.Combine(folder, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                return new OkObjectResult(new FileResponse
                {
                    FileName = fileName,
                    FilePath = Path.Combine(fileFolder, fileName).Replace(@"\", @"/")
                });
            }
        }
    }
}
