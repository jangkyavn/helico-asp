using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Service.Helpers
{
    public static class EncodeImage
    {
        public static string ConvertBase64(this string image, IHostingEnvironment hostingEnvironment, string folderPath)
        {
            if (string.IsNullOrEmpty(image))
            {
                return string.Empty;
            }

            string fullPath = Path.Combine(hostingEnvironment.WebRootPath, folderPath + image);
            string[] array = image.Split(".");
            string type = array[array.Length - 1];
            string result = $@"data:image/{type};base64,{Convert.ToBase64String(File.ReadAllBytes(fullPath))}";
            return result;
        }
    }
}
