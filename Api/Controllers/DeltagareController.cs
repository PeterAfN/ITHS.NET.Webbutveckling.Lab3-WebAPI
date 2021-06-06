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
    [Route("api/deltagare")]
    public class DeltagareController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeltagareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllDeltagare()
        {
            var result = await _unitOfWork.GetDeltagareRepository().GetDeltagareAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeltagare(int id)
        {
            try
            {
                var deltagare = await _unitOfWork.GetDeltagareRepository().GetDeltagareByIdAsync(id);

                if (deltagare == null) return NotFound();
                return Ok(deltagare);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("find/{email}")]
        public async Task<IActionResult> GetDeltagare(string email)
        {
            try
            {
                var deltagare = await _unitOfWork.GetDeltagareRepository().GetDeltagareByEmailAsync(email);

                if (deltagare == null) return NotFound();
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
                await _unitOfWork.GetDeltagareRepository().AddAsync(deltagare);

                if (await _unitOfWork.GetDeltagareRepository().SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeltagare(int id, Deltagare deltagareModel)
        {
            var deltagare = await _unitOfWork.GetDeltagareRepository().GetDeltagareByIdAsync(id);

            deltagare.Förnamn = deltagareModel.Förnamn;
            deltagare.Efternamn = deltagareModel.Efternamn;
            deltagare.Epost = deltagareModel.Epost;
            deltagare.Mobilnummer = deltagareModel.Mobilnummer;
            deltagare.Adress = deltagareModel.Adress;
            deltagare.City = deltagareModel.City;
            deltagare.StateProvince = deltagareModel.StateProvince;
            deltagare.PostalCode = deltagareModel.PostalCode;
            deltagare.Country = deltagareModel.Country;

            _unitOfWork.GetDeltagareRepository().Update(deltagare);
            var result = await _unitOfWork.GetDeltagareRepository().SaveAllChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeltagare(int id)
        {
            try
            {
                var deltagare = await _unitOfWork.GetDeltagareRepository().GetDeltagareByIdAsync(id);

                if (deltagare == null) return NotFound();

                _unitOfWork.GetDeltagareRepository().Delete(deltagare);

                var result = _unitOfWork.GetDeltagareRepository().SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}