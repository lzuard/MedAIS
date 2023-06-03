using MedData.Data;
using MedData.Entities.Base;
using MedData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedData.Repositories.Base
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _set;

        public bool AutoSaveChanges = false;

        public virtual IQueryable<T> Items => _set;


        public DbRepository(ApplicationContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }


        public T Get(int id) => Items.SingleOrDefault(i => i.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancel = default) => await Items
            .SingleOrDefaultAsync(i => i.Id == id, cancel)
            .ConfigureAwait(false);

        public T Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges)
                _context.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            if (entities is null) throw new ArgumentNullException(nameof(entities));
            _context.AddRange(entities);
            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
            return entity;
        }

        public void Update(T entity)
        {
            var oldEntity = Items.FirstOrDefault(i => i.Id == entity.Id);
            if (oldEntity is null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public void Delete(int id)
        {
            _context.Remove(new T { Id = id });

            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        public async Task DeleteAsync(int id, CancellationToken cancel = default)
        {
            _context.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
