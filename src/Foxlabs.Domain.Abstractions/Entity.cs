using System.Collections.Generic;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for entities which belong to an <see cref="AggregateRoot" />.
    /// </summary>
    public abstract class Entity : IEntity
    {
        private List<IDomainEvent> _domainEvents;
        
        private int? _requestedHashCode;

        protected Entity() { }

        protected Entity(int id)
        {
            Id = id;
        }

        /// <summary>
        /// The read-only collection of domain events for the entity.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// The unique identifier of this entity.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets whether the entity is transient, and has not been persisted.
        /// </summary>
        /// <value>
        /// <c>True</c> if the entity is not-persisted, otherwise <c>false</c>.
        /// </value>
        public bool IsTransient => Id.Equals(default);

        /// <summary>
        /// Add an <see cref="IDomainEvent" /> to the entity.
        /// </summary>
        public void AddDomainEvent(IDomainEvent @event)
        {
            (_domainEvents ??= new List<IDomainEvent>()).Add(@event);
        }

        /// <summary>
        /// Clears the collection of <see cref="IDomainEvent" />s on the entity.
        /// </summary>
        public void ClearDomainEvents()
            => _domainEvents?.Clear();

        /// <summary>
        /// Remove an <see cref="IDomainEvent" /> from the entity.
        /// </summary>
        public void RemoveDomainEvent(IDomainEvent @event)
            => _domainEvents?.Remove(@event);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            Entity item = (Entity)obj;

            if (item.IsTransient || IsTransient)
            {
                return false;
            }

            return item.Id.Equals(Id);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            if (!IsTransient)
            {
                if (!_requestedHashCode.HasValue)
                {
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <inheritdoc />
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }
            else
            {
                return left.Equals(right);
            }
        }

        /// <inheritdoc />
        public static bool operator !=(Entity left, Entity right)
            => !(left == right);
    }
}
