using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Services.Settings;

namespace TregHunt.Services.API
{
    public class PubMedApiService : ApiService
    {
        public PubMedApiService(PubMedApiSettings settings, IRestClient restClient) : base (settings, restClient) {}
    }
}
