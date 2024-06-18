using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot
    { 
        long Version { get; }
    }

    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntity<TKey>, IAggregateRoot
        where TKey : IComparable
    {
    }
}
