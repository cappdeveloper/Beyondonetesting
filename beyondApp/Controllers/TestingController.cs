using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace beyondApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly ILogger<TestingController> _logger;

        public TestingController(ILogger<TestingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("FirstTask")]
        public  ActionResult<string> GetType()
        {
            var _formatServer = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);            
            return Ok(new { _formatServer });
        }

    }
}
