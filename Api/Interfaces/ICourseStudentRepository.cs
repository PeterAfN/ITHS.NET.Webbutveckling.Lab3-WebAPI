using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface ICourseStudentRepository
    {
        Task AddAsync(CourseStudent courseStudent);
        Task<IEnumerable<CourseStudent>> GetCoursesStudentsAsync();
        void Update(CourseStudent courseStudent);
        void Delete(CourseStudent courseStudent);
        Task<bool> SaveAllChangesAsync();
    }
}