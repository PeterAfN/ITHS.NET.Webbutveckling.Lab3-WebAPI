using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface IKursRepository
    {
        Task AddAsync(Kurs kurs);
        Task<IEnumerable<Kurs>> GetKurserAsync();

        Task<Kurs> GetKursByIdAsync(int id);

        Task<Kurs> GetKursByKursnummerAsync(string kursnummer);

        void Update(Kurs kurs);

        void Delete(Kurs kurs);

        Task<bool> SaveAllChangesAsync();
    }
}