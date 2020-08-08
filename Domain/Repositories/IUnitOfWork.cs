using System.Threading;
using System.Threading.Tasks;

namespace LimKam.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        Task CompleteAsync(CancellationToken token);
    }
}