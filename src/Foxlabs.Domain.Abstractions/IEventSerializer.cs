using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for providing serialization of events to the persistence layer.
    /// </summary>
    public interface IEventSerializer
    {
        /// <summary>
        /// Deserialize the event with the type name and binary representation specified.
        /// </summary>
        /// <returns><see cref="IDomainEvent" /></returns>
        IDomainEvent Deserialize(string type, byte[] data);

        /// <summary>
        /// Deserialize the event with the type name and string representation specified.
        /// </summary>
        /// <returns><see cref="IDomainEvent" /></returns>
        IDomainEvent Deserialize(string type, string data);

        /// <summary>
        /// Serializes the event as a byte array.
        /// </summary>
        byte[] Serialize(IDomainEvent @event);
    }
}
