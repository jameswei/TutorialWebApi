using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TutorialWebApi
{
    // In Program class, ASP.NET configure and launch a generic host, which is responsible for startup and lifetime
    // management. At a minimum, the host configures a server and a request-response processing pipeline .
    public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        // CreateDefaultBuilder performs the following by default:
        // 1. set content root path to the path returned by GetCurrentDirectory()
        // 2. load host configurations from Env variables with prefix DOTNET_. and command-line arguments
        // 3. load app configuration from appsettings.json and appsettings.{Env}.json, secrets manager, Env variables, and command-line arguments
        // 4. add the following logging providers, Console, Debug, and EventSource
        // 5. enable scoped validation and dependency validation only when Env is Development.
        Host.CreateDefaultBuilder(args)
            // ConfigureWebHostDefaults performs the following by default:
            // 1. load host configuration frrom Env variables with prefix ASPNETCORE_.
            // 2. set Kestrel server as the web server and configure it using app configuration
            // 3. add host filtering middleware
            // 4. add forward headers middleware
            // 5. enable IIS integration
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
}
