using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Route._3TiersArchitecture.PL.Helpers
{
    public class DocumentUploader
    {

        public static string UploadFile(IFormFile file, string FolderName)
        {
            //1- get Located Folder Path
            //string folderPath = $"D:\\Files\\study\\1- Route\\Back End\\ASP\\C#\\07 ASP.NET Core MVC\\1- Main Demos\\Route.3TiersArchitectureSolution\\Route.3TiersArchitecture.PL\\wwwroot\\Files\\{FolderName}";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);


            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //2- Get File Name And make it unique
            string FileName = $"{Guid.NewGuid()} {Path.GetExtension(file.FileName)}";

            //3- Get File Path
            string filePath = Path.Combine(folderPath, FileName);


            //4- Save File as Stream[Data]

            using var FileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(FileStream);


            return FileName;

        }

        public static void DeleteFile(string fileName, string FolderName)
        {
            string filePath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, fileName);
            if (File.Exists(filePath)) 
                File.Delete(filePath);
          


        }




    }
}
