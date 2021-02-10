using Microsoft.Extensions.Configuration;
using System;
using TregHunt.Bootstrap;
using TregHunt.Contracts.Services;

namespace TregHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Startup.Bootstrap();

            var applicationPrompts = container.GetInstance<IApplicationPrompts>();

            applicationPrompts.Greeting();

            //var filePath = GetUserFileLocation(Configuration);
        }

        private static string GetUserFileLocation(IConfiguration config)
        {


            var userFilePath = Console.ReadLine();
            if (userFilePath.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                return config["FileLocation"];
            }

            return userFilePath;
        }
    }
}
