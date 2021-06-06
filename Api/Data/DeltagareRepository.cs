using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DeltagareRepository : IDeltagareRepository
    {
        private readonly DataContext _context;
        public DeltagareRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Deltagare deltagare)
        {
            await _context.Deltagare.AddAsync(deltagare);
        }

        public void Delete(Deltagare deltagare)
        {
            _context.Deltagare.Remove(deltagare);
        }

        public async Task<IEnumerable<Deltagare>> GetDeltagareAsync()
        {
            return await _context.Deltagare.ToListAsync();
        }

        public async Task<Deltagare> GetDeltagareByIdAsync(int id)
        {
            return await _context.Deltagare.FindAsync(id);
        }

        public async Task<Deltagare> GetDeltagareByEmailAsync(string email)
        {
            var deltagare = await _context.Deltagare./*Include(d => d.Epost).*/FirstOrDefaultAsync(
                c => c.Epost.ToUpper() == email.ToUpper());

            return deltagare;
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Deltagare deltagare)
        {
            _context.Deltagare.Update(deltagare);
        }
    }
}