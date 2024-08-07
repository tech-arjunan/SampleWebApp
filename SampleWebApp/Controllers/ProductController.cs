using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;
using SampleWebApp.Repositories;
using System.Text.Json;

namespace SampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var result = JsonSerializer.Serialize(_repository.GetAll());
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var result = JsonSerializer.Serialize(product);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            _repository.Add(product);
            return Ok();
        }
    }
}
