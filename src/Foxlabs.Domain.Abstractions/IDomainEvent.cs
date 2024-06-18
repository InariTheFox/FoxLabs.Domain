﻿using MediatR;
using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for a domain event.
    /// </summary>
    public interface IDomainEvent : INotification
    {
        IAggregateRoot RootAggregate { get; }

        long RootVersion { get; }

        DateTimeOffset Timestamp { get; }
    }

    /// <summary>
    /// The basic interface for a domain event.
    /// </summary>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IDomainEvent<TKey> : IDomainEvent
        where TKey : IComparable
    {
        TKey RootId { get; }
    }
}