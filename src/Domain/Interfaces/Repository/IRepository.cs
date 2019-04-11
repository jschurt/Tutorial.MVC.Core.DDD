using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : EntidadeBase
    {
        void Add(T obj);

        void Update(T obj);

        void Remove(T obj);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

        int SaveChanges();

    } //interface

} //namespace
