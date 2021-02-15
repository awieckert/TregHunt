﻿using Microsoft.Extensions.Configuration;
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

            var filePath = applicationPrompts.GetFilePathFromUser();

            container.GetInstance<ISearchTermImporter>().Import(filePath);
        }
    }
}
