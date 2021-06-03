
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/deltagare")]
    public class DeltagareController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllDeltagare()
        {
            var data = new { id = "1", förnamn = "Peter" };
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeltagare(int id)
        {
            var data = new { id = "1", förnamn = "Peter" };
            return Ok(data);
        }

        [HttpPost()]
        public async Task<IActionResult> AddDeltagare(Object model)
        {
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeltagare(Int16 id, object model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeltagare(Int16 id)
        {

            return NoContent();
        }

    }
}