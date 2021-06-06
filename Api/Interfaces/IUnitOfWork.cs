using System.Threading.Tasks;
namespace Api.Interfaces
{
    public interface IUnitOfWork
    {
        IKursRepository GetKursRepository();

        IDeltagareRepository GetDeltagareRepository();

        IKursDeltagareRepository GetKursDeltagareRepository();

        Task<bool> Complete();

        bool HasChanges();
    }
}