using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TregHunt.Contracts.Services;


namespace TregHunt.Services
{
    public class ApplicationPrompts : IApplicationPrompts
    {
        readonly IConfiguration _config;

        public ApplicationPrompts(IConfiguration config)
        {
            _config = config;
        }
        public void Greeting()
        {
            Console.WriteLine("Welcome to TregHunt! A pubmed searching utiliy.");
            Console.WriteLine("You supply TregHunt with an excel spreadsheet of your custom search terms and it'll search PubMed for you!");
            Console.WriteLine("Please see the README at https://github.com/awieckert/TregHunt for detailed instructions on how to use TregHunt");

            Console.WriteLine("*******************************");
            Console.WriteLine(@"Please provide your excel file with search terms.");
        }

        public string GetFilePathFromUser()
        {
            var doWhile = true;
            var filePath = "";

            while (doWhile)
            {
                Console.WriteLine("Default [D], or provide the full file path (Example: C:\\Documents\\excelFile.xlsx)");

                var userFilePath = Console.ReadLine();
                if (userFilePath.Equals("d", StringComparison.OrdinalIgnoreCase))
                {
                    filePath = _config["FileLocation"];
                    doWhile = false;
                    continue;
                }

                if (!File.Exists(userFilePath))
                {
                    Console.WriteLine("File does not exist at the specified path. Please try again or use the default file with option [D]");
                    continue;
                }

                filePath = userFilePath;
                doWhile = false;
            }

            return filePath;
        }
    }
}
