using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ZwajApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Take args (code -Logic) To Build and Run the Solution
            CreateWebHostBuilder(args).Build().Run();
        }

        //Dependancy Injection
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
