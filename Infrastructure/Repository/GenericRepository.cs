using Microsoft.EntityFrameworkCore;
using UseCases;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly IUnitOfWork<T> _unitOfWork;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(IUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Cannot find Entity[ID={id}]");
            }
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
        }
    }
}
