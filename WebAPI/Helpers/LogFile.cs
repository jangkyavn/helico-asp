using System;
using System.IO;

namespace WebAPI.Helpers
{
    public class LogFile
    {
        public static void Create(string message)
        {
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            using (StreamWriter writer = File.AppendText($"Logs/core-{DateTime.Now:yyyyMMdd}.txt"))
            {
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": " + message);
            }
        }
    }
}
