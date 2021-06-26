using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Data
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly DataContext _context;
        public CourseStudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CourseStudent courseStudent)
        {
            await _context.CoursesStudents.AddAsync(courseStudent);
        }

        public void Delete(CourseStudent courseStudent)
        {
            _context.CoursesStudents.Remove(courseStudent);
        }

        public async Task<IEnumerable<CourseStudent>> GetCoursesStudentsAsync()
        {
            return await _context.CoursesStudents.ToListAsync();
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(CourseStudent courseStudent)
        {
            _context.CoursesStudents.Update(courseStudent);
        }
    }

}
