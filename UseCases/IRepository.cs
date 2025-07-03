﻿namespace UseCases
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(int id);
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
