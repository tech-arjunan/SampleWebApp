using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Models;
using SampleWebApp.Repositories;
using System.Text.Json;

namespace SampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserRepository _repository;
        public UserController()
        {
            _repository = new UserRepository();
        }
        public IActionResult Index()
        {
            var result = JsonSerializer.Serialize(_repository.GetAll());
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = JsonSerializer.Serialize(_repository.GetById(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _repository.Add(user);
            return Ok();
        }

    }
}
