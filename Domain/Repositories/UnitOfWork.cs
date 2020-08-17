using LimKam.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LimKam.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        { 
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}