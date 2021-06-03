using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/kurser")]
    public class KurserController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetKurser()
        {
            var data = new { id = "1", kurstitel = "JavaScript: Introduktion" };
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKurs(int id)
        {
            var data = new { id = "1", kurstitel = "JavaScript fördjupningkurs 1" };
            return Ok(data);
        }

        [HttpPost()]
        public async Task<IActionResult> AddKurs(Object model)
        {
            return StatusCode(201);
        }
    }
}