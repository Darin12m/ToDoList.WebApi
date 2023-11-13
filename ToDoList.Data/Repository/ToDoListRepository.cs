using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Databse;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repository
{
    public class ToDoListRepository : BaseRepository<ToDoLists>, IToDoListRepository
    {
        public ToDoListRepository(ToDoListDbContext dbContext) 
            : base(dbContext)
        {
        }

        public IEnumerable<ToDoLists> GetTasks(int userId, string title, string? description 
            ,string orderBy = "Title", bool isAsc = true)
        {
            IQueryable<ToDoLists> query = dbContext
                .Tasks
                .Where(x => x.User.Id == userId );

            

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(x => x.Description != null && x.Description.Contains(description));
            }


            Expression<Func<ToDoLists, object>>? orderByExpression = null;

            if (orderBy.ToLower() == nameof(ToDoLists.Description).ToLower())
            {
                orderByExpression = ToDoList => ToDoList.Description;
            }

            else
            {
                orderByExpression = ToDoList => ToDoList.Title;
            }

            if (isAsc)
            {
                query = query.OrderBy(orderByExpression);
            }

            else
            {
                query = query.OrderByDescending(orderByExpression);
            }

            return query.ToList();
        }
    }
}