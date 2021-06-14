using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface ICourseStudentRepository
    {
        Task AddAsync(CourseStudent courseStudent);
        Task<IEnumerable<CourseStudent>> GetCoursesStudentsAsync();
        // Task<IEnumerable<CourseStudent>> GetAllCoursesStudentsByEmail(string email);
        void Update(CourseStudent courseStudent);
        void Delete(CourseStudent courseStudent);
        Task<bool> SaveAllChangesAsync();
    }
}