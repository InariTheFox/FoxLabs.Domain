using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for entities which belong to an <see cref="AggregateRoot" />.
    /// </summary>
    public abstract class Entity: Entity<int>
    {
        protected Entity()
            : base() { }

        protected Entity(int id)
            : base(id) { }
    }

    /// <summary>
    /// The base class for entities which belong to an <see cref="AggregateRoot" />.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public abstract class Entity<TKey> : IEntity<TKey>
        where TKey : IComparable
    {
        private int? _requestedHashCode;

        protected Entity() { }

        protected Entity(TKey id)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of this entity.
        /// </summary>
        public TKey Id { get; protected set; }

        /// <summary>
        /// Gets whether the entity is transient, and has not been persisted.
        /// </summary>
        /// <value>
        /// <c>True</c> if the entity is not-persisted, otherwise <c>false</c>.
        /// </value>
        public bool IsTransient => Id?.Equals(default) ?? true;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TKey>))
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

            Entity<TKey> item = (Entity<TKey>)obj;

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
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }

        /// <inheritdoc />
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
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
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
            => !(left == right);
    }
}
