﻿using System;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The basic interface for a respository of aggregate entities of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    /// <typeparam name="TKey">The entity key type.</typeparam>
    public interface IRepository<TAggregate, TKey> where TAggregate : IAggregateRoot<TKey>
        where TKey: IComparable
    {
        /// <summary>
        /// The unit of work associated with the repository.
        /// </summary>
        /// <remarks>
        /// The unit of work usually is the realization of the persistence layer. For example,
        /// when using Entity Framework, this will be the DbContext.
        /// </remarks>
        IUnitOfWork UnitOfWork { get; }
    }

    /// <summary>
    /// The basic interface for a respository of aggregate entities of <paramref name="TAggregate" />.
    /// </summary>
    /// <typeparam name="TAggregate">The derived aggregate root entity.</typeparam>
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot<int>
    {
        /// <summary>
        /// The unit of work associated with the repository.
        /// </summary>
        /// <remarks>
        /// The unit of work usually is the realization of the persistence layer. For example,
        /// when using Entity Framework, this will be the DbContext.
        /// </remarks>
        IUnitOfWork UnitOfWork { get; }
    }
}
