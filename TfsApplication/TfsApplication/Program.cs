using System;
using System.Collections.ObjectModel;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;




namespace TfsApplication
{
    class Program
    {
        static void Main(String[] args)
        {
            // Connect to Team Foundation Server
            //     Server is the name of the server that is running the application tier for Team Foundation.
            //     Port is the port that Team Foundation uses. The default port is 8080.
            //     VDir is the virtual path to the Team Foundation application. The default path is tfs.
            string teamProjectCollectionUrl = @"http://179.159.128.195:8080";
            Uri tfsUri = (args.Length < 1) ?
                new Uri(teamProjectCollectionUrl) : new Uri(args[0]);

            

            TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(teamProjectCollectionUrl));
            VersionControlServer versionControlServer = teamProjectCollection.GetService<VersionControlServer>();

            
            var items = versionControlServer.GetItems("$/Financial.BMF").Items;            
            foreach (Item item in items)
            {
                item.DownloadFile();
            }
            
            

        }
    }
}