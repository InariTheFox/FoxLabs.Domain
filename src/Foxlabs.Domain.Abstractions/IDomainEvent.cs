using MediatR;
using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for a domain event.
    /// </summary>
    public interface IDomainEvent  : INotification
    {
        int RootId { get; }

        long RootVersion { get; }

        DateTimeOffset Timestamp { get; }
    }
}