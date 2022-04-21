using Microsoft.EntityFrameworkCore;
using RR_app.DAL;
using RR_app.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DBContext Context { get; set; }
        public RepositoryBase(DBContext dbContext)
        {
            Context = dbContext;
        }
        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => Context.Set<T>().Add(entity);
        public void Update(T entity) => Context.Set<T>().Update(entity);
        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
