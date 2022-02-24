using System;
using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(Guid id, T entity);

        void UpdateList(T entity, T entityOld);
        void Delete(Guid id);

        
    }
}