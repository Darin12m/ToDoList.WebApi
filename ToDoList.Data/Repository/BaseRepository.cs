using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Databse;

namespace ToDoList.Data.Repository
{
    public abstract class BaseRepository<T> 
        : IRepository<T> where T : class
    {
        protected readonly ToDoListDbContext dbContext;

        public BaseRepository(ToDoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T? GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
