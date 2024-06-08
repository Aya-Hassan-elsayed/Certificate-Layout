using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Certificit.PL.Helper
{
    public class DecoumentSeting
    {
        public static string UploadImage(IFormFile formFile , string FolderName)
        {
            // 1 - Get Folder Path Dynamic 
            string FolderPath = Path.Combine("/var/www/app", "wwwroot" , FolderName);
            // 2 - Get File Image Unique 
            string FileName = $"{Guid.NewGuid()}{formFile.FileName}";
            // 3 - Get Image Path 
            string FilePath = Path.Combine(FolderPath, FileName);            
            // 4- Save Image In server 
            using var fs = new FileStream(FilePath, FileMode.Create);
            // 5 - Return File Name  
            formFile.CopyTo(fs);
             fs.Close();
            return $"{FolderName}{FileName}";
        }
         public static int DeleteImage (string FileName)
         {
            string FilePath = Path.Combine ("/var/www/app", "wwwroot", FileName);

            if (File.Exists(FilePath))
            {
               File.Delete(FilePath);
                return 1;
            }
            return 0;
         }

        public static string UpdateFile(IFormFile formFile,string FileName , string FolderName)
        {
            DeleteImage(FileName);
          return  UploadImage(formFile, FolderName);
        }
    }
}
