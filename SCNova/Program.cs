using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Starcounter.Nova.AspNetCore;

namespace SCNova
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string databaseName = "default";

            if (!Starcounter.Nova.Options.StarcounterOptions.TryOpenExisting(databaseName))
            {
                Directory.CreateDirectory(databaseName);
                Starcounter.Nova.Bluestar.ScCreateDb.Execute(databaseName);
            }

            using (var appHost = new Starcounter.Nova.Hosting.AppHostBuilder()
                .UseDatabase(databaseName)
                .Build())
            {
                using (var webHost = BuildWebHost(args, appHost))
                {
                    webHost.Run();
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args, Starcounter.Nova.Abstractions.IAppHost appHost) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddStarcounter(appHost);
                })
                .UseStartup<Startup>()
                .Build();
    }
}
