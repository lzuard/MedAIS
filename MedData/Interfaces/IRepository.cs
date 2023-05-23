using System.Collections.Generic;

namespace MedData.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Contains all repository data
        /// </summary>
        IQueryable<T> Items { get; }

        /// <summary>
        /// Return entity by id
        /// </summary>
        T Get(int id);

        /// <summary>
        /// Async return entity by id
        /// </summary>
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        /// <summary>
        /// Add entity to repository and returns it
        /// </summary>
        T Add(T entity);

        /// <summary>
        /// Async add entity to repository and returns it
        /// </summary>
        Task<T> AddAsync(T entity, CancellationToken cancel = default);
        
        /// <summary>
        /// Updates the entity
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Async updates the entity
        /// </summary>
        Task UpdateAsync(T entity, CancellationToken cancel = default);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// Async deletes entity by id
        /// </summary>
        Task DeleteAsync(int id, CancellationToken cancel = default);
    }
}
