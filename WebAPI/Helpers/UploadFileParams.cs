using Microsoft.AspNetCore.Http;

namespace WebAPI.Helpers
{
    public class UploadFileParams
    {
        public string FolderType { get; set; }
        public string FolderName { get; set; }
        public IFormFile File { get; set; }
    }
}
