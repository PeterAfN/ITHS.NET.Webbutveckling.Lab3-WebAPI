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

        public IDeltagareRepository GetDeltagareRepository()
        {
            return new DeltagareRepository(_context);
        }

        public IKursRepository GetKursRepository()
        {
            return new KursRepository(_context);
        }

        public IKursDeltagareRepository GetKursDeltagareRepository()
        {
            return new KursDeltagareRepository(_context);
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