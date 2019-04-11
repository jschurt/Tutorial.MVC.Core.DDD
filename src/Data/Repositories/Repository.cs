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

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        } //Add

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
        } //Update

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
        } //Remove

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        } //GetAll

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        } //GetById

        public int SaveChanges()
        {
            return _context.SaveChanges();
        } //SaveChanges

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            //return _context.Set<T>().Where(predicate);
            return _context.Set<T>().AsNoTracking().Where(predicate);
        } //Search


        public void Dispose()
        {
            _context.Dispose();
        } //Dispose



    } //class

} //namespace
