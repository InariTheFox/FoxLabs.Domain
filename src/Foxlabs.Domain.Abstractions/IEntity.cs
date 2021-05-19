using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// A collection of <see cref="IDomainEvent" />s.
        /// </summary>
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets whether the entity has been persisted or not.
        /// </summary>
        bool IsTransient { get; }

        /// <summary>
        /// Adds an <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        void AddDomainEvent(IDomainEvent @event);

        /// <summary>
        /// Clears the collection of <see cref="IDomainEvent" />s on the entity.
        /// </summary>
        void ClearDomainEvents();

        /// <summary>
        /// Remove an <see cref="IDomainEvent" /> from the entity.
        /// </summary>
        void RemoveDomainEvent(IDomainEvent @event);
    }
}