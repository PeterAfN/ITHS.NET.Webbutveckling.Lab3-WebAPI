using System;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/course")]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet()]
        public async Task<IActionResult> GetCourses()
        {
            var result = await _unitOfWork.GetCourseRepository().GetCoursesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                var course = await _unitOfWork.GetCourseRepository().GetCourseByIdAsync(id);
                if (course == null) return NotFound();
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }  

        [HttpPost()]
        public async Task<IActionResult> AddCourse(Course course)
        {
            try
            {
                await _unitOfWork.GetCourseRepository().AddAsync(course);
                if (await _unitOfWork.GetCourseRepository().SaveAllChangesAsync()) return StatusCode(201);
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course courseModel)
        {
            var course = await _unitOfWork.GetCourseRepository().GetCourseByIdAsync(id);

            course.Id = courseModel.Id;
            course.Titel = courseModel.Titel;
            course.Description = courseModel.Description;
            course.Length = courseModel.Length;
            course.Difficulty = courseModel.Difficulty;
            course.Status = courseModel.Status;

            _unitOfWork.GetCourseRepository().Update((Course)course);
            var result = await _unitOfWork.GetCourseRepository().SaveAllChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var course = await _unitOfWork.GetCourseRepository().GetCourseByIdAsync(id);
                if (course == null) return NotFound();
                _unitOfWork.GetCourseRepository().Delete(course);
                var result = _unitOfWork.GetCourseRepository().SaveAllChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}