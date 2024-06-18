using System;
using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for all aggregate domain entities.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public abstract class AggregateRoot<TAggregate> : AggregateRoot<TAggregate, int>
        where TAggregate : class, IAggregateRoot<int>
    {
        protected AggregateRoot()
            : base() { }

        protected AggregateRoot(int id)
            : base(id) { }

        /// <summary>
        /// Applies the <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        /// <remarks>
        protected override abstract void Apply(IDomainEvent<int> @event);
    }

    /// <summary>
    /// The base class for all aggregate domain entities.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public abstract class AggregateRoot<TAggregate, TKey> : Entity<TKey>, IAggregateRoot<TKey>
        where TAggregate : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        protected AggregateRoot()
            : base() { }

        protected AggregateRoot(TKey id)
            : base(id)
        { }

        /// <summary>
        /// The version of the aggregate.
        /// </summary>
        public long Version { get; protected set; }

        /// <summary>
        /// Create an instance of <paramref name="TAggregate" />.
        /// </summary>
        /// <returns><paramref name="TAggregate" /></returns>
        /// <typeparam name="TAggregate">The derivied aggregate root entity.</typeparam>
        public static TAggregate Create(IEnumerable<IDomainEvent<TKey>> events)
        {
            Check.NotEmpty(events, nameof(events));

            var instance = Activator.CreateInstance<TAggregate>();
            var method = typeof(AggregateRoot<>).GetMethod(nameof(Apply));

            foreach (var @event in events)
            {
                method.Invoke(instance, new object[] { @event });
            }

            return instance;
        }

        /// <summary>
        /// Applies the <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        /// <remarks>
        protected abstract void Apply(IDomainEvent<TKey> @event);
    }
}
