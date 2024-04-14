using E_store.Models;
using E_store.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace E_store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult getShirts()
        {
            return Ok("Reading all shirt");
        }
        [HttpGet("{id}")]
        public IActionResult getShirtById(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null)
                return NotFound();

            return Ok(shirt);
        }
        [HttpPost]
        public IActionResult createShirt([FromBody]Shirt shirt)
        {
            return Ok("created a shirt");
        }
        [HttpPut("{id}")]
        public IActionResult updateShirt(int id)
        {
            return Ok($"shirt updated od id : {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteShirt(int id)
        {
            return Ok($"shirt deleted of id : {id}");
        }
    }
}
