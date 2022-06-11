using beyondApp.Clients;
using beyondApp.Dtos;
using beyondApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace beyondApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> _logger;
        private readonly PostsClient _clientpost;

        public TestingController(ILogger<TestingController> logger, PostsClient postClient)
        {
            _logger = logger;
            _clientpost = postClient;
        }

        [HttpGet("SecondTask")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPost()
        {
            var _refindedPosts = await _clientpost.GetPosts();
            return Ok(_refindedPosts);
        }


    }
}
