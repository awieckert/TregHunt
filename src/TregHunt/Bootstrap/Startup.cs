using Lamar;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TregHunt.Services.Settings;

namespace TregHunt.Bootstrap
{
    public class Startup
    {
        public static IContainer Bootstrap()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{CurrentEnvironment}.json", true, true);

            var config = builder.Build();

            var container = new Container(c => 
            {
                c.Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory(a => a.GetName().Name.StartsWith("TregHunt", StringComparison.OrdinalIgnoreCase));
                    scanner.With(new SettingsConvention(config));
                    scanner.WithDefaultConventions();
                });

                c.For<IConfiguration>().Use(config);
                c.For<IRestClient>().Use<RestClient>();
            });

            return container;
        }

        public static string CurrentEnvironment
        {
            get
            {
                var environmentName = Environment.GetEnvironmentVariable("TREGHUNT_ENVIRONMENT");

                Console.WriteLine($"Current environment is {environmentName}");

                return environmentName;
            }
        }
    }


}
