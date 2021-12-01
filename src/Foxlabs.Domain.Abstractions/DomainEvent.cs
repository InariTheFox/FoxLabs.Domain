using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for domain events of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class DomainEvent<TAggregate> : DomainEvent<TAggregate, int>
        where TAggregate : class, IAggregateRoot<int>
    {

    }

    /// <summary>
    /// The base class for domain events of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public abstract class DomainEvent<TAggregate, TKey> : IDomainEvent<TKey>
        where TAggregate : class, IAggregateRoot<TKey>
        where TKey: IComparable
    {
        protected DomainEvent() { }

        protected DomainEvent(TAggregate aggregate)
        {
            Check.NotNull(aggregate, nameof(aggregate));

            RootId = aggregate.Id;
            RootVersion = aggregate.Version;
            Timestamp = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// The unique identifier of the root entity.
        /// </summary>
        public TKey RootId { get; private set; }

        /// <summary>
        /// The version of the root entity at the time of this event.
        /// </summary>
        public long RootVersion { get; private set; }

        /// <summary>
        /// The timestamp of when this event was fired.
        /// </summary>
        public DateTimeOffset Timestamp { get; private set; }
    }
}
