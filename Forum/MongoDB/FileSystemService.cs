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

        private String pathCreate =
            $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgCreate/")}";

        private String pathList = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/wwwroot/imgList/")}";

        private readonly ILogger<FileSystemService> _logger;

        public List<String> UploadImageToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            List<String> listNames = new List<string>();

            List<String> imgNames = GetNamesOfDir("imgSource");

            foreach (var name in imgNames)
            {
                listNames.Add(name);
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{path}{name}", FileMode.Open))
                {
                    gridFS.UploadFromStream(name, fs);
                }
            }

            return imgNames;
        }

        public static List<String> UploadImageToDb(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            List<String> listNames = new List<string>();
            List<String> imgNames = GetNamesOfDir(folder);
            
            foreach (var name in imgNames)
            {
                listNames.Add(name);
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{path}{name}", FileMode.Open))
                {
                    gridFS.UploadFromStream(name, fs);
                }
            }

            return imgNames;
        }
        
        public void UploadCreateImgToDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");


            List<String> imgNames = GetNamesOfDir("imgCreate");

            foreach (var name in imgNames)
            {
                var gridFS = new GridFSBucket(database);

                using (FileStream fs = new FileStream($"{pathCreate}{name}", FileMode.Open))
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

        public static void DownloadToLocalByName(String name, String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            List<String> imgNames = GetFindByName();
            List<String> loadImgNames = new List<string>();

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var gridFS = new GridFSBucket(database);

            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";

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

        public static List<String> GetNamesOfDir(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";

            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            DirectoryInfo info = new DirectoryInfo($"{path}");

            List<String> listNames = new List<string>();

            foreach (var item in info.GetFiles())
            {
                listNames.Add(item.Name);
            }

            return listNames;
        }
        
        
        public static String GetNameOfDir(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
        
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            path = path.Replace("/", @"\");
            DirectoryInfo info = new DirectoryInfo($"{path}");

            List<String> listNames = new List<string>();
        
            foreach (var item in info.GetFiles())
            {
                listNames.Add(item.Name);
            }
        
            
            if (listNames.Count == 1)
            {
                return listNames[0].ToString();;
            }
            return "";
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
        
        public static void RemoveFolder(String folder)
        {
            String pathFolder = $"/wwwroot/{folder}/";
            
            String path = $"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + pathFolder)}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
 
            foreach (FileInfo f in dirInfo.GetFiles())
            {
                f.Delete();
            }
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