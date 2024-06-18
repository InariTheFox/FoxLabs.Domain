using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an entity.
    /// </summary>
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    }

    /// <summary>
    /// The basic interface for an entity.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IEntity<TKey> : IEntity
        where TKey : IComparable
    {
        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Gets whether the entity has been persisted or not.
        /// </summary>
        [JsonIgnore]
        bool IsTransient { get; }

        /// <summary>
        /// A collection of <see cref="IDomainEvent" />s.
        /// </summary>
        new IReadOnlyCollection<IDomainEvent<TKey>> DomainEvents { get; }

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