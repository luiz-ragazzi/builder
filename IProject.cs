using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Builder
{
    public interface IProjectBuild
    {
        List<String> ProjectsPath { get; set; }
        bool Build();

    }
}
