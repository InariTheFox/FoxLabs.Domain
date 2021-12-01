using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<int>
    { }

    /// <summary>
    /// The basic interface for an aggregate root entity.
    /// </summary>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
        where TKey : IComparable
    {
        long Version { get; }
    }
}
