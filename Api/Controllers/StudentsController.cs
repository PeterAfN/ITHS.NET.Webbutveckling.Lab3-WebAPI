using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _unitOfWork.GetStudentRepository().GetStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _unitOfWork.GetStudentRepository().GetStudentByIdAsync(id);

                if (student == null) return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("find/{email}")]
        public async Task<IActionResult> GetStudent(string email)
        {
            try
            {
                var student = await _unitOfWork.GetStudentRepository().GetStudentByEmailAsync(email);

                if (student == null) return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> AddStudent(Student student)
        {
            try
            {
                await _unitOfWork.GetStudentRepository().AddAsync(student);

                if (await _unitOfWork.GetStudentRepository().SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student studentModel)
        {
            var student = await _unitOfWork.GetStudentRepository().GetStudentByIdAsync(id);

            student.FirstName = studentModel.FirstName;
            student.LastName = studentModel.LastName;
            student.Mail = studentModel.Mail;
            student.Mobile = studentModel.Mobile;
            student.Address = studentModel.Address;
            student.City = studentModel.City;
            student.StateProvince = studentModel.StateProvince;
            student.PostalCode = studentModel.PostalCode;
            student.Country = studentModel.Country;

            _unitOfWork.GetStudentRepository().Update(student);
            var result = await _unitOfWork.GetStudentRepository().SaveAllChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _unitOfWork.GetStudentRepository().GetStudentByIdAsync(id);

                if (student == null) return NotFound();

                _unitOfWork.GetStudentRepository().Delete(student);

                var result = _unitOfWork.GetStudentRepository().SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}