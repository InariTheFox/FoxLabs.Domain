using System;
using System.Text.Json.Serialization;

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
        /// The identifier of the entity.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Gets whether the entity has been persisted or not.
        /// </summary>
        [JsonIgnore]
        bool IsTransient { get; }
    }
}