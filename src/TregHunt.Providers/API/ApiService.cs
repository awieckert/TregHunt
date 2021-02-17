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

        RestRequest CreateRequest(Method method)
        {
            var request = new RestRequest(method);
            _restClient.ThrowOnAnyError = true;
            return request;
        }

        public T Get<T>(string url) where T : class, new()
        {
            try
            {
                var request = CreateRequest(Method.GET);

                _restClient.BaseUrl = new Uri($"{_settings.BaseUrl}/{url}{(!string.IsNullOrWhiteSpace(_settings.ApiKey) ? $"&api_key={_settings.ApiKey}" : "")}");

                var response = _restClient.Get<T>(request);

                return response.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TResult Post<TBody, TResult>(string url, TBody content) where TResult : class, new()
        {
            var request = CreateRequest(Method.POST);
        }
    }
}
