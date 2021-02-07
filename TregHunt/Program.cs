using Microsoft.Extensions.Configuration;
using System;

namespace TregHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

            var wtf = Configuration.GetSection("FileLocation");
            var filePath = GetUserFileLocation(Configuration);
            var test = 2;
        }

        private static string GetUserFileLocation(IConfiguration config)
        {
            Console.WriteLine("Welcome to TregHunt! A pubmed searching utiliy.");
            Console.WriteLine("You supply TregHunt with an excel spreadsheet of your custom search terms.");
            Console.WriteLine("Please see the README at https://github.com/awieckert/TregHunt for instructions on how to use TregHunt");
            Console.WriteLine("*******************************");
            Console.WriteLine(@"Please provide your excel file with search terms. 
                                You may either use the default excel file and location 
                                or provide the path to your own excel file.");
            Console.WriteLine("Default [D], or provide the full file path (C:\\Documents\\excelFile.xlsx)");

            var userFilePath = Console.ReadLine();
            if (userFilePath.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                return config["FileLocation"];
            }

            return userFilePath;
        }
    }
}
