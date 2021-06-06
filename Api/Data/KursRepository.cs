using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class KursRepository : IKursRepository
    {
        private readonly DataContext _context;
        public KursRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Kurs kurs)
        {
            await _context.Kurser.AddAsync(kurs);
        }

        public void Delete(Kurs kurs)
        {
            _context.Kurser.Remove(kurs);
        }

        public async Task<Kurs> GetKursByIdAsync(int id)
        {
            return await _context.Kurser.FindAsync(id);
        }

        public async Task<Kurs> GetKursByKursnummerAsync(string kursnummer)
        {
            // return await _context.Kurser.FindAsync(kursnummer);

            var kurs = await _context.Kurser./*Include(d => d.Epost).*/FirstOrDefaultAsync(k => k.Kursnummer.Equals(int.Parse(kursnummer)));

            return kurs;
        }

        public async Task<IEnumerable<Kurs>> GetKurserAsync()
        {
            return await _context.Kurser.ToListAsync();
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Kurs kurs)
        {
            _context.Kurser.Update(kurs);
        }
    }
}