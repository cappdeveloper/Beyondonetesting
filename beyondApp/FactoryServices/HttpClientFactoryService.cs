using beyondApp.Clients;
using beyondApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace beyondApp.FactoryServices
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PostsClient _postsClient;
        private readonly JsonSerializerOptions _options;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory, PostsClient postsClient)
        {
            _httpClientFactory = httpClientFactory;
            _postsClient = postsClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        

       
    }
}
