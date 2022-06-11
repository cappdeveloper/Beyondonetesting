using beyondApp.Models;
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
        private readonly ProductsContext _dbcontext;
        private readonly ILogger<TestingController> _logger;

        public TestingController(ILogger<TestingController> logger, ProductsContext productContext)
        {
            _dbcontext = productContext;
            _logger = logger;
        }

        [HttpGet("Products")]
        public ActionResult<ProductsViewModel> GetProducts()
        {
            var _data = _dbcontext.Products.Select(x => new { x.id, x.product_id, x.product_name }).ToList();
            return Ok(_data);
        }

        [HttpPost("Products")]
        public ActionResult<string> GetProductsQuantity([FromQuery] int product_id, int quantity)
        {
            string _message = "Not found";
            var _data = (from p in _dbcontext.Products
                         where p.product_id == product_id
                         select p).FirstOrDefault();

            int _quantityDB = _data.stock_available;
            if (_quantityDB >= quantity) _message = "Item Found";
            else _message = "No stock Available";

            return Ok(new { _message });

        }
    }
}
