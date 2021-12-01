using System;
using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for all aggregate domain entities.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class AggregateRoot<TAggregate> : AggregateRoot<TAggregate, int>
        where TAggregate : class, IAggregateRoot
    {
        protected AggregateRoot(int id)
            : base(id) { }
    }

    /// <summary>
    /// The base class for all aggregate domain entities.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class AggregateRoot<TAggregate, TKey> : Entity<TKey>, IAggregateRoot<TKey>
        where TAggregate : class, IAggregateRoot
        where TKey : IComparable
    {
        protected AggregateRoot() { }

        protected AggregateRoot(TKey id)
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
            where T : AggregateRoot<TAggregate, TKey>
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
