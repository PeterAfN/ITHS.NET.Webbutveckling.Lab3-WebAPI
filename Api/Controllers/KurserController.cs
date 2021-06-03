using System;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var result = await _context.Kurser.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKurs(int id)
        {
            try
            {
                var kurs = await _context.Kurser.SingleOrDefaultAsync(k => k.Id == id);
                return Ok(kurs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddKurs(Kurs kurs)
        {
            try
            {
                _context.Kurser.Add(kurs);
                var result = await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKurs(int id, Kurs kursModel)
        {
            var kurs = await _context.Kurser.FindAsync(id);

            kurs.Kursnummer = kursModel.Kursnummer;
            kurs.Kurstitel = kursModel.Kurstitel;
            kurs.Kursbeskrivning = kursModel.Kursbeskrivning;
            kurs.Kurslängd = kursModel.Kurslängd;
            kurs.Nivå = kursModel.Nivå;
            kurs.Status = kursModel.Status;

            _context.Update(kurs);
            var result = await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurs(int id)
        {
            try
            {
                var kurs = await _context.Kurser.SingleOrDefaultAsync(k => k.Id == id);
                if (kurs == null) return NotFound();

                _context.Kurser.Remove(kurs);
                var result = _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
    }
}