using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class KursDeltagareRepository : IKursDeltagareRepository
    {
        private readonly DataContext _context;
        public KursDeltagareRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddAsync(KursDeltagare kursDeltagare)
        {
            await _context.KursDeltagare.AddAsync(kursDeltagare);
        }

        public void Delete(KursDeltagare kursDeltagare)
        {
            _context.KursDeltagare.Remove(kursDeltagare);
        }

        public async Task<IEnumerable<KursDeltagare>> GetKursDeltagareAsync()
        {
            return await _context.KursDeltagare.ToListAsync();
        }

        public async Task<KursDeltagare> GetKursDeltagareByIdAsync(int id)
        {
            return await _context.KursDeltagare.FindAsync(id);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(KursDeltagare kursDeltagare)
        {
            _context.KursDeltagare.Update(kursDeltagare);
        }
    }

}
