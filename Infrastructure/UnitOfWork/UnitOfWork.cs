using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using UseCases;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;
        private bool _disposed;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            _disposed = false;
        }

        public DbContext Db => _context;

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Reverts all pending changes.
        /// Cancel modifications before they're committed to the database.
        /// </summary>
        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        /// <summary>
        /// Implements IDisposable to release resources when the UnitOfWork is no longer needed.
        /// This enables using the UnitOfWork within a 'using' statement for automatic cleanup.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="dispose">True if called directly by user code; 
        /// False if called by the garbage collector finalizer</param>
        protected void Dispose(bool dispose)
        {
            if (!_disposed)
            {
                if (dispose)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
