using System.Threading.Tasks;
namespace Api.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository GetCourseRepository();
        IStudentRepository GetStudentRepository();
        ICourseStudentRepository GetCourseStudentRepository();
        Task<bool> Complete();
        bool HasChanges();
    }
}