using System.Reflection.Metadata.Ecma335;
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
    [Route("api/kursdeltagare")]
    public class KursDeltagareController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public KursDeltagareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllKursDeltagare()
        {
            var result = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKursDeltagare(int id)
        {
            try
            {
                var kursDeltagare = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareByIdAsync(id);

                if (kursDeltagare == null) return NotFound();
                return Ok(kursDeltagare);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddKursDeltagare(KursDeltagare kursDeltagare)
        {
            try
            {
                await _unitOfWork.GetKursDeltagareRepository().AddAsync(kursDeltagare);

                if (await _unitOfWork.GetKursDeltagareRepository().SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKursDeltagare(int id, KursDeltagare kursDeltagareModel)
        {
            var kursDeltagare = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareByIdAsync(id);

            kursDeltagare.Deltagare = kursDeltagareModel.Deltagare;
            kursDeltagare.DeltagareId = kursDeltagareModel.DeltagareId;
            kursDeltagare.Kurs = kursDeltagareModel.Kurs;
            kursDeltagare.KursId = kursDeltagareModel.KursId;

            _unitOfWork.GetKursDeltagareRepository().Update(kursDeltagare);
            var result = await _unitOfWork.GetKursDeltagareRepository().SaveAllChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKursDeltagare(int id)
        {
            try
            {
                var kursDeltagare = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareByIdAsync(id);

                if (kursDeltagare == null) return NotFound();

                _unitOfWork.GetKursDeltagareRepository().Delete(kursDeltagare);

                var result = _unitOfWork.GetKursDeltagareRepository().SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}