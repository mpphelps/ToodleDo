using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToodleDo.Core.Entities;
using ToodleDo.Core.Enums;
using ToodleDo.Core.IRepositories;

namespace ToodleDo.DataAccess.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ToDoContext context)
        :base(context)
        {
        }

        public IEnumerable<ToDoItem> GetHighPriorityItems(Priority priority)
        {
            return ToDoContext.ToDoItems.OrderByDescending(t => t.Priority == Priority.High);
        }

        public IEnumerable<ToDoItem> GetCriticalPriorityItems(Priority priority)
        {
            return ToDoContext.ToDoItems.OrderByDescending(t => t.Priority == Priority.Critical);
        }

        public IEnumerable<ToDoItem> GetItemWithOwner(int pageIndex, int pageSize)
        {
            return ToDoContext.ToDoItems
                .Include(o => o.Owner)
                .OrderBy(t => t.Priority)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ToDoContext ToDoContext
        {
            get { return Context as ToDoContext;  }
        }
    }
}