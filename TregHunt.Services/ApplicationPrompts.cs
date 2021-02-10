using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Services;
using Microsoft.Extensions.Configuration;


namespace TregHunt.Services
{
    public class ApplicationPrompts : IApplicationPrompts
    {
        private IConfiguration _config;

        public ApplicationPrompts(IConfiguration config)
        {
            _config = config;
        }
        public void Greeting()
        {
            Console.WriteLine("Welcome to TregHunt! A pubmed searching utiliy.");
            Console.WriteLine("You supply TregHunt with an excel spreadsheet of your custom search terms.");
            Console.WriteLine("Please see the README at https://github.com/awieckert/TregHunt for instructions on how to use TregHunt");
            Console.WriteLine("*******************************");
            Console.WriteLine(@"Please provide your excel file with search terms. 
                                You may either use the default excel file and location 
                                or provide the path to your own excel file.");
            Console.WriteLine("Default [D], or provide the full file path (C:\\Documents\\excelFile.xlsx)");
        }
    }
}
