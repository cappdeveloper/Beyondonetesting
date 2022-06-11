using beyondApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace beyondApp.Clients
{
    public class PostsClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public PostsClient(HttpClient client)
        {
            _client = client;
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.Timeout = new TimeSpan(0, 0, 30);
            client.DefaultRequestHeaders.Clear();

            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<PostDto>> GetPosts()
        {
            using (var response = await _client.GetAsync("posts", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var posts = await JsonSerializer.DeserializeAsync<List<PostDto>>(stream, _options);
                posts = posts.Where(x => x.Body.Contains("minima")).OrderBy(x => x.Id).ToList();
                return posts;
            }
        }

        private async Task GetURLWithTypedClient()
        {
            using (var response = await _client.GetAsync("posts", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var companies = await JsonSerializer.DeserializeAsync<List<PostDto>>(stream, _options);
            }
        }
    }
}
