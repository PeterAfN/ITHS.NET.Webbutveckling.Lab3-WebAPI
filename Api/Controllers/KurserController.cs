using System;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/kurser")]
    public class KurserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public KurserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetKurser()
        {
            var result = await _unitOfWork.GetKursRepository().GetKurserAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKurs(int id)
        {
            try
            {
                var kurs = await _unitOfWork.GetKursRepository().GetKursByIdAsync(id);
                if (kurs == null) return NotFound();
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
                await _unitOfWork.GetKursRepository().AddAsync(kurs);

                if (await _unitOfWork.GetKursRepository().SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKurs(int id, Kurs kursModel)
        {
            var kurs = await _unitOfWork.GetKursRepository().GetKursByIdAsync(id);

            kurs.Kursnummer = kursModel.Kursnummer;
            kurs.Kurstitel = kursModel.Kurstitel;
            kurs.Kursbeskrivning = kursModel.Kursbeskrivning;
            kurs.Kurslängd = kursModel.Kurslängd;
            kurs.Nivå = kursModel.Nivå;
            kurs.Status = kursModel.Status;

            _unitOfWork.GetKursRepository().Update(kurs);
            var result = await _unitOfWork.GetKursRepository().SaveAllChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurs(int id)
        {
            try
            {
                var kurs = await _unitOfWork.GetKursRepository().GetKursByIdAsync(id);

                if (kurs == null) return NotFound();

                _unitOfWork.GetKursRepository().Delete(kurs);
                var result = _unitOfWork.GetKursRepository().SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}