using Microsoft.EntityFrameworkCore;

namespace UseCases
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        DbContext Db { get; }
        void Save();
        void Edit(T entity);
        void Rollback();
    }
}
