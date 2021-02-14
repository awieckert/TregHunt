using System;

namespace TregHunt.Contracts.Services
{
    public interface IApplicationPrompts
    {
        void Greeting();
        string GetFilePathFromUser();
    }
}
