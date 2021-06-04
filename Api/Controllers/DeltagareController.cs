using System;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/deltagare")]
    public class DeltagareController : ControllerBase
    {
        private readonly DataContext _context;

        public DeltagareController(DataContext context)
        {
            _context = context;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllDeltagare()
        {
            var result = await _context.Deltagare.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeltagare(int id)
        {
            try
            {
                var deltagare = await _context.Deltagare.SingleOrDefaultAsync(d => d.Id == id);
                return Ok(deltagare);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddDeltagare(Deltagare deltagare)
        {
            try
            {
                _context.Deltagare.Add(deltagare);
                var result = await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeltagare(int id, Deltagare deltagareModel)
        {
            var deltagare = await _context.Deltagare.FindAsync(id);

            deltagare.Förnamn = deltagareModel.Förnamn;
            deltagare.Efternamn = deltagareModel.Efternamn;
            deltagare.Epost = deltagareModel.Epost;
            deltagare.Mobilnummer = deltagareModel.Mobilnummer;
            deltagare.Adress = deltagareModel.Adress;
            deltagare.City = deltagareModel.City;
            deltagare.StateProvince = deltagareModel.StateProvince;
            deltagare.PostalCode = deltagareModel.PostalCode;
            deltagare.Country = deltagareModel.Country;
            _context.Update(deltagare);
            var result = await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeltagare(int id)
        {
            try
            {
                var deltagare = await _context.Deltagare.SingleOrDefaultAsync(d => d.Id == id);
                if (deltagare == null) return NotFound();

                _context.Deltagare.Remove(deltagare);
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