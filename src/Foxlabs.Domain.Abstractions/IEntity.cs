using System;
using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an entity.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IEntity<TKey>
        where TKey : IComparable
    {
        /// <summary>
        /// A collection of <see cref="IDomainEvent" />s.
        /// </summary>
        IReadOnlyCollection<IDomainEvent<TKey>> DomainEvents { get; }

        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Gets whether the entity has been persisted or not.
        /// </summary>
        bool IsTransient { get; }

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