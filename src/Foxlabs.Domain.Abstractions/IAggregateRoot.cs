using System;
using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<int>
    { }

    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
        where TKey : IComparable
    {
        /// <summary>
        /// A collection of <see cref="IDomainEvent" />s.
        /// </summary>
        IReadOnlyCollection<IDomainEvent<TKey>> DomainEvents { get; }

        long Version { get; }

        /// <summary>
        /// Adds an <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        void AddDomainEvent(IDomainEvent<TKey> @event);

        /// <summary>
        /// Clears the collection of <see cref="IDomainEvent" />s on the entity.
        /// </summary>
        void ClearDomainEvents();

        /// <summary>
        /// Remove an <see cref="IDomainEvent" /> from the entity.
        /// </summary>
        void RemoveDomainEvent(IDomainEvent<TKey> @event);
    }
}
