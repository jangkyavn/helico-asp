using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Service.Helpers
{
    public static class EncodeImage
    {
        public static string ConvertBase64(this string image, IHostingEnvironment hostingEnvironment, string folderPath)
        {
            string fullPath = Path.Combine(hostingEnvironment.WebRootPath, folderPath + image);
            string result = @"data:image/jpg;base64," + Convert.ToBase64String(File.ReadAllBytes(fullPath));
            return result;
        }
    }
}
