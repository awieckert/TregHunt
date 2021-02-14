using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Services
{
    public interface ISearchTermImporter
    {
        void Import(string filePath);
    }
}
