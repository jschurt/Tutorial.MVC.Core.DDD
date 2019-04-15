using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces
{

    public interface IApplicationGenericCrud<T> where T : class
    {

        T Add(T obj);
        T Update(T obj);
        T Remove(T obj);

        IEnumerable<T> GetAll();
        T GetById(int id);

        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

    } //interface


}
