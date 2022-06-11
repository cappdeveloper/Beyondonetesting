using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace beyondApp.Dtos
{
    public class PostDto
    {
        [JsonPropertyName("userid")]
        public int UserId { get; set; }
        
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }


    }
}
