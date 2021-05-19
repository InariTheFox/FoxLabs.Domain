using System;
using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for all aggregate domain entities.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class AggregateRoot<TAggregate> : Entity, IAggregateRoot
        where TAggregate : class, IAggregateRoot
    {
        protected AggregateRoot() { }

        protected AggregateRoot(int id)
            : base(id)
        { }

        /// <summary>
        /// The version of the aggregate.
        /// </summary>
        public long Version { get; private set; }

        /// <summary>
        /// Applies the <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        /// <remarks>
        protected abstract void Apply(IDomainEvent @event);

        /// <summary>
        /// Create an instance of <paramref name="TAggregate" />.
        /// </summary>
        /// <returns><paramref name="TAggregate" /></returns>
        /// <typeparam name="TAggregate">The derivied aggregate root entity.</typeparam>
        public static T Create<T>(IEnumerable<IDomainEvent> events)
            where T : AggregateRoot<TAggregate>
        {
            Check.NotEmpty(events, nameof(events));

            var instance = Activator.CreateInstance<T>();

            foreach (var @event in events)
            {
                instance.Apply(@event);
            }

            return instance;
        }
    }
}
