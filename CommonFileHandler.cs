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
        /// <summary>
        /// Seleciona arquivos
        /// Financial.*, com extensão .dll e Aquivos com extensão . compiled
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetFiles(DirectoryInfo directory)
        {
            //Pegar os arquivos Financial.*, com extensão .dll
            var financialFiles =  directory.GetFiles().Where(s => s.Name.Remove(s.Name.Length - s.Extension.Length, s.Extension.Length).Length >= 9).Where(x => x.Name.Substring(0, 9).ToLower() == "financial").Where(f => f.Extension == ".dll").ToArray();
            //concatena com os compiled
            return directory.GetFiles().Where(x => x.Extension == ".compiled").Concat(financialFiles).ToArray();
            
            
            
        }
    }
}
