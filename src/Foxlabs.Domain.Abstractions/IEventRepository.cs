using System.Threading.Tasks;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an event repository used in persisting aggregates of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public interface IEventRepository<TAggregate>
        where TAggregate : class, IAggregateRoot
    {
        /// <summary>
        /// Append the events for the aggregate specified to the persistence layer.
        /// </summary>
        Task AppendAsync(TAggregate aggregate);

        /// <summary>
        /// Rehydrate the aggregate with the persisted events to return it to it's current
        /// state.
        /// </summary>
        Task<TAggregate> RehydrateAsync(int key);
    }
}
