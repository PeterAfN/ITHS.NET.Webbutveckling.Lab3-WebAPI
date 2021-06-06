using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface IKursDeltagareRepository
    {
        Task AddAsync(KursDeltagare kursDeltagare);
        Task<IEnumerable<KursDeltagare>> GetKursDeltagareAsync();

        Task<KursDeltagare> GetKursDeltagareByIdAsync(int id);

        void Update(KursDeltagare kursDeltagare);

        void Delete(KursDeltagare kursDeltagare);

        Task<bool> SaveAllChangesAsync();
    }
}