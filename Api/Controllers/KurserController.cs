using System;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/kurser")]
    public class KurserController : ControllerBase
    {
        private readonly DataContext _context;


        //gör om till repository när det fungerar
        public KurserController(DataContext context)
        {
            _context = context;
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKurs(Int16 id, object model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurs(Int16 id)
        {

            return NoContent();
        }
    }
}