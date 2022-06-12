using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MyBiz.Helpers
{
    public static class FileManager
    {
        public static string Save(string root , string folder , IFormFile file)
        {
            var newFileName=Guid.NewGuid().ToString()+file.FileName;
            var path=Path.Combine(root,folder,newFileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return newFileName;
        }
        public static bool Delete(string root , string folder , string fileName)
        {

            var path = Path.Combine(root, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
            
        }
    }
}
