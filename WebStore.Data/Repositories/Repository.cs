using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Data.IRepositories;
using WebApplication_Models;

namespace WebApplication_Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet.AsQueryable();
            return query;
        }
        public T? GetById(Expression<Func<T, bool>> filter)
        {
            T? item = DbSet.FirstOrDefault(filter);
            return item;
        }
        public T? Add(T entity)
        {
            if(entity == null)
            {
                return null;
            }

            // Categories.Add(category);
            DbSet.Add(entity);
            var NumberOfUpdates =  context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity;
            else
                return null;
        }

        public T? Remove(T entity)
        {
            if(entity == null)
            {
                return null;
            }
            DbSet.Remove(entity);
            var NumberOfUpdates = context.SaveChanges();
            if (NumberOfUpdates > 0)
                return entity;
            else
                return null;
        }
    }
}
