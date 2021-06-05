using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface IDeltagareRepository
    {
        Task AddAsync(Deltagare deltagare);
        Task<IEnumerable<Deltagare>> GetDeltagareAsync();

        Task<Deltagare> GetDeltagareByIdAsync(int id);

        void Update(Deltagare deltagare);

        void Delete(Deltagare deltagare);

        Task<bool> SaveAllChangesAsync();
    }
}