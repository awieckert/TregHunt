using RestSharp;
using RestSharp.Serialization.Xml;
using System;
using System.Collections.Generic;
using System.Text;
using TregHunt.Contracts.Services;
using TregHunt.Services.Settings;

namespace TregHunt.Services.API
{
    public class ApiService : IApiService
    {
        readonly ApiBaseSettings _settings;
        readonly IRestClient _restClient;

        public ApiService(ApiBaseSettings settings, IRestClient restClient)
        {
            _settings = settings;
            _restClient = restClient;
        }

        RestRequest CreateXmlRequest(Method method)
        {
            var request = new RestRequest(method);
            _restClient.ThrowOnAnyError = true;
            return request;
        }

        public T Get<T>(string url) where T : class, new()
        {
            try
            {
                var request = CreateXmlRequest(Method.GET);

                _restClient.BaseUrl = new Uri($"{_settings.BaseUrl}/{url}{(!string.IsNullOrWhiteSpace(_settings.ApiKey) ? $"&api_key={_settings.ApiKey}" : "")}");

                var response = _restClient.Get<T>(request);
                //TODO: Data is coming back on the response.content. Investigate this.
                return response.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
