using System.Threading.Tasks;
using Api.Interfaces;

namespace Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IStudentRepository GetStudentRepository()
        {
            return new StudentRepository(_context);
        }

        public ICourseRepository GetCourseRepository()
        {
            return new CourseRepository(_context);
        }

        public ICourseStudentRepository GetCourseStudentRepository()
        {
            return new CourseStudentRepository(_context);
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}