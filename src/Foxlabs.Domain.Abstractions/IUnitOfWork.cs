using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for the unit of work implementation.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Perisists changes asynchronously to the backing store.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Persists all entities asynchronously to the backing store.
        /// </summary>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}