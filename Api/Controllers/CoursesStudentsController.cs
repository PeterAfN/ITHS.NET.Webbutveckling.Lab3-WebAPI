using System.ComponentModel;
using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/courseStudent")]
    public class CoursesStudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesStudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetAllCoursesStudents()
        {
            var result = await _unitOfWork.GetCourseStudentRepository().GetCoursesStudentsAsync();

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AddCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                await _unitOfWork.GetCourseStudentRepository().AddAsync(courseStudent);

                if (await _unitOfWork.GetCourseStudentRepository().SaveAllChangesAsync()) return StatusCode(201);

                return StatusCode(400); //duplicate -> "bad request"
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{studentEmail}")]
        public async Task<IActionResult> GetAllCoursesStudents(string studentEmail)
        {
            try
            {
                var result = await _unitOfWork.GetCourseStudentRepository().GetCoursesStudentsAsync();

                IEnumerable<CourseStudent> cS = result.Where(c => c.Student.Mail == "peterpalosaari@live.se");
                // IEnumerable<CourseStudent> cS = result.Where(c => c.StudentId == 59);

                if (cS == null) return NotFound();
                return Ok(cS);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete()]
        public IActionResult DeleteCourseStudent(CourseStudent courseStudent)
        {
            try
            {
                _unitOfWork.GetCourseStudentRepository().Delete(courseStudent);
                var result = _unitOfWork.GetCourseStudentRepository().SaveAllChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}