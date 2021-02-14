﻿using Lamar;
using Microsoft.Extensions.Configuration;
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
                .AddJsonFile("appsettings.json", false, true);

            var config = builder.Build();

            var container = new Container(c => 
            {
                c.For<IConfiguration>().Use(config);

                c.Scan(scanner =>
                {
                    scanner.AssembliesFromApplicationBaseDirectory(a => a.GetName().Name.StartsWith("TregHunt", StringComparison.OrdinalIgnoreCase));
                    scanner.With(new SettingsConvention(config));
                    scanner.WithDefaultConventions();
                });
            });

            return container;
        }
    }
}