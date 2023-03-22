using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Forum.MongoDB
{
    public class FileSystemService
    {
        private String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgSource/")}";
        private String pathCreate = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgCreate/")}";
        private String pathList = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgList/")}";

        private readonly ILogger<FileSystemService> _logger;

        public void UploadImageToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            
            
            List<String> imgNames = GetNamesOfDir();

            foreach (var name in imgNames)
            {
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{path}{name}", FileMode.Open))
                {
                    gridFS.UploadFromStream(name, fs);
                }
            }
        }

        public List<String> DownloadToLocal()
        {
           // path = path.Replace(@"\","/" );
            List<String> imgNames = GetFindByName();
            List<String> loadImgNames = new List<string>();

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var gridFS = new GridFSBucket(database);

            
                foreach (var name in imgNames)
                {
                    try
                    {
                        using (FileStream fs = new FileStream($"{path}{name}", FileMode.CreateNew))
                        {
                            gridFS.DownloadToStreamByName(name, fs);
                           
                        }
                        loadImgNames.Add(name);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"a file named {name} already exists");
                        // _logger.LogError($"a file named {name} already exists");
                    }

                }
            return loadImgNames;
        }
        
        public static List<String> GetNamesOfDir()
        {
           // String path = "C:/Users/Petov/source/repos/BlazorPMLabsUnits/BlazorPMLabsUnits/wwwroot/imgSource/";
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgSource/")}";
            path = path.Replace("/", @"\");
            DirectoryInfo info = new DirectoryInfo($"{path}");

            List<String> listNames = new List<string>(); 

            foreach (var item in info.GetFiles())
            {
                listNames.Add(item.Name);
            }

            return listNames;
        }
        
        public static List<String> GetFindByName()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var gridFS = new GridFSBucket(database);
            var collection = database.GetCollection<GridFSFileInfo>("fs.files");

            var strNames = collection.Find(x => x.Filename != null).ToEnumerable<GridFSFileInfo>();
            
            return strNames.Select(x => x.Filename).ToList<String>();

        }
        
        public static void ClearDB()
        {
            var client = new MongoClient("mongodb://localhost");
            client.GetDatabase("Forum").DropCollectionAsync("fs.files");
            client.GetDatabase("Forum").DropCollectionAsync("fs.chunks");
        }

        public static void DeleteImgLocal(String name)
        {
            // String path = $"C:/Users/Petov/source/repos/BlazorPMLabsUnits/BlazorPMLabsUnits/wwwroot/imgSource/{name}";
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgSource/")}{name}";
           
            FileInfo file = new FileInfo(path);
            file.Delete();
        }
        
        // public static void AddImgLocal(String path)
        // {
        //     String[] pathRoot = path.Split(@"\");
        //     // string sourceFile = path;
        //     string sourceFile = path.Replace("/", @"\");
        //     string destinationFile = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\wwwroot\imgSource\")}{pathRoot[pathRoot.Length-1]}";
        //     
        //     
        //     System.IO.File.Move(sourceFile, destinationFile);
        //     
        //     string sourceDir = "";
        //     
        //     for (int i = 0; i < pathRoot.Length-1; i++)
        //     {
        //         sourceDir += pathRoot[i] + @"\";
        //     }
        //     System.IO.Directory.Move(sourceDir, $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgSource/")}");
        // }
        
        public static async Task UploadImageToDbAsync(Stream fs, string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var gridFS = new GridFSBucket(database);

            await gridFS.UploadFromStreamAsync(name, fs);
        }
       
    }
}