using System;
using System.Collections.Generic;
using System.Text;

namespace TregHunt.Contracts.Services
{
    public interface IApiService
    {
        T Get<T>(string url) where T : class, new();
    }
}
