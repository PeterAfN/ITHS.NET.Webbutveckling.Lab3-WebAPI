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

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetKursDeltagare(int id)
        // {
        //     try
        //     {
        //         var kursDeltagare = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareByIdAsync(id);

        //         if (kursDeltagare == null) return NotFound();
        //         return Ok(kursDeltagare);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, ex.Message);
        //     }
        // }


        [HttpGet("{KursId},{DeltagareId}")]
        public async Task<IActionResult> GetKursDeltagare(int KursId, int DeltagareId)
        {
            try
            {
                var kursD = await _unitOfWork.GetKursDeltagareRepository().GetKursDeltagareByIdAsync(KursId, DeltagareId);

                if (kursD == null) return NotFound();
                return Ok(kursD);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete()]
        public IActionResult DeleteKursDeltagare(KursDeltagare kursDeltagare)
        {
            try
            {
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