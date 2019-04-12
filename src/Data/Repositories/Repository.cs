using Data.Context;
using Domain.Entities.Shared;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntidadeBase
    {

        protected ContextEF _context;

        public Repository(ContextEF context)
        {
            _context = context;
        } //constructor

        public virtual void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        } //Add

        public virtual void Update(T obj)
        {
            _context.Set<T>().Update(obj);
        } //Update

        public virtual void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
        } //Remove

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        } //GetAll

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        } //GetById

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        } //SaveChanges

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            //return _context.Set<T>().Where(predicate);
            return _context.Set<T>().AsNoTracking().Where(predicate);
        } //Search


        public virtual void Dispose()
        {
            _context.Dispose();
        } //Dispose

    } //class

} //namespace
