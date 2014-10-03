using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    public class CommonFileHandler
    {
        public static IEnumerable<FileInfo> GetFiles(DirectoryInfo directory)
        {
            //Pegar os arquivos Financial.*, .compiled e  Financial.*(.dll)
            
            
            return directory.GetFiles().Where(s => s.Extension == ".dll" || s.Extension == ".compiled" || s.Name.Remove(s.Name.Length - s.Extension.Length, s.Extension.Length).ToLower() == "financial").ToArray();
            
        }
    }
}
