using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface ICourseStudentRepository
    {
        Task AddAsync(CourseStudent courseStudent);
        Task<IEnumerable<CourseStudent>> GetCoursesStudentsAsync();
        Task<CourseStudent> GetCourseStudentByIdAsync(int courseId, int studentId);
        void Update(CourseStudent courseStudent);
        void Delete(CourseStudent courseStudent);
        Task<bool> SaveAllChangesAsync();
    }
}