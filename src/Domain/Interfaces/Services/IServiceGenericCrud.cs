using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServiceGenericCrud<T> where T : EntidadeBase
    {

        T Add(T obj);
        T Update(T obj);
        T Remove(T obj);

        IEnumerable<T> GetAll();
        T GetById(int id);

        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

    } //interface
} //namespace
