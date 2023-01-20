using MediatR;
using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for a domain event.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IDomainEvent<TKey> : INotification
        where TKey : IComparable
    {
        IAggregateRoot RootAggregate { get; }

        TKey RootId { get; }

        long RootVersion { get; }

        DateTimeOffset Timestamp { get; }
    }
}