using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for domain events of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class DomainEvent<TAggregate> : IDomainEvent
        where TAggregate : class, IAggregateRoot
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
        public int RootId { get; private set; }

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
