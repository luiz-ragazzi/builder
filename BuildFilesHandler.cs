using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*Master
namespace Financial.Builder
{
    public class BuildFilesHandler
    {
        public static void HandleFiles(string projectPathLine)
        {

            var directoryProject= Directory.GetParent(Path.GetDirectoryName(projectPathLine));

            string pastaDeploy = Path.Combine(directoryProject.FullName, "Deploy");
            string binPath = Path.Combine(pastaDeploy, "bin");
          
            var sb = new StringBuilder();
            

            //na pasta \bin
            var directoryInfo = new DirectoryInfo(binPath);
            var fixedFiles = directoryInfo.GetFiles().Where(s => s.Extension == ".dll" || s.Extension == ".compiled" || s.Name.Remove(s.Name.Length - s.Extension.Length, s.Extension.Length).ToLower() == "financial");

            var allFiles = directoryInfo.GetFiles();
            foreach (var item in allFiles)
            {
                var exists = (from s in fixedFiles where s.Name == item.Name select item.Name).SingleOrDefault();
                if (exists == null)
                    File.Delete(item.FullName);
            }
            //no nivel acima da bin
            string[] directories = { "cssCustom", "Downloads", "customReport", "imagensPersonalizadas", "interfacesCustom", "jsCustom", "loginCustom", "Teste", "WebServicesCustom" };
            var directoriesName = new StringBuilder();
            foreach (string directory in directories)
            {
                directoriesName.Clear();
                directoriesName.Append(Path.Combine(pastaDeploy, directory));
                if (Directory.Exists(directoriesName.ToString()))
                {
                    string[] filesInside = Directory.GetFiles(directoriesName.ToString());
                    foreach (string fileInside in filesInside)
                    {
                        File.SetAttributes(fileInside, FileAttributes.Normal);
                        File.Delete(fileInside);
                    }

                    Directory.Delete(directoriesName.ToString(), true);
                }
            }
            var directoryRoot = new DirectoryInfo(pastaDeploy);

            var configs = directoryRoot.GetFiles("*.config");
            foreach (var item in configs)
            {
                if (item.Name.ToLower() == "web.config")
                    item.Delete();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Arquivos removidos com sucesso!");

            
        }


        public static void CopyFile(FileInfo fi, string destination)
        {

            fi.CopyTo(destination, true);
        }
    }
}
