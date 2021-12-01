using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for providing serialization of events to the persistence layer.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IEventSerializer<TKey>
        where TKey : IComparable
    {
        /// <summary>
        /// Deserialize the event with the type name and binary representation specified.
        /// </summary>
        /// <returns><see cref="IDomainEvent{TKey}" /></returns>
        IDomainEvent<TKey> Deserialize(string type, byte[] data);

        /// <summary>
        /// Deserialize the event with the type name and string representation specified.
        /// </summary>
        /// <returns><see cref="IDomainEvent{TKey}" /></returns>
        IDomainEvent<TKey> Deserialize(string type, string data);

        /// <summary>
        /// Serializes the event as a byte array.
        /// </summary>
        byte[] Serialize(IDomainEvent<TKey> @event);
    }
}
