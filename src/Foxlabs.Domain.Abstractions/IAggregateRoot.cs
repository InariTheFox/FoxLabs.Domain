using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        long Version { get; }
    }
}
