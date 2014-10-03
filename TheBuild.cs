using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Builder
{
    public class TheBuild :IProjectBuild
    {

        public TheBuild()
        {
            this.ProjectsPath = new List<string>();
            this.OutputPath = new Dictionary<string, string>();
        }
        
        public List<string> Errors = new List<string>();

        public Dictionary<string,string> OutputPath { get; private set;}

        public bool Build()
        {
            Errors.Clear();
            bool isBuild = true;

            if (this.ProjectsPath == null || this.ProjectsPath.Count == 0)
                throw new NullReferenceException("Projetos para compilação não foram definidos. Popular a lista em ProjetsPath");
            
            foreach (var path in ProjectsPath)
            {
                var project = new Microsoft.Build.Evaluation.Project(path);
                
                isBuild = project.Build();


                if (!OutputPath.ContainsKey(@"C:\Projetos\lib"))
                    OutputPath.Add(@"C:\Projetos\lib", @"C:\Projetos\lib");

                if (!isBuild)
                    Errors.Add(path);
            }

            return isBuild;

        }

        //branch new feature;;

        public List<string> ProjectsPath
        {
            get;
            set;
        }
    }
}
