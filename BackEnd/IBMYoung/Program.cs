using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IBMYoung
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool runSeed = false;
      
            if (args.Contains("seed")){
                runSeed = true;
                args = args.Where(d => d != "seed").ToArray();
            }
            var host = BuildWebHost(args);
            if (runSeed) RunSeed(host);

            host.Run();
        }

        private static async Task RunSeed(IWebHost host) {
            Console.WriteLine("Seeding...");
            using (var scope = host.Services.CreateScope()) {
                var context = scope.ServiceProvider.GetService<Db>();
                try {
                    await DbSeeder.Seed(context);
                } catch (Exception ex) {
                    Console.WriteLine(ex.GetBaseException().Message);
                } finally {
                    Console.WriteLine("Seed ended");
                    Console.ReadKey();
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
