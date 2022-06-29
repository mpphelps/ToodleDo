using System.Collections.Generic;
using ToodleDo.Core.Entities;
using ToodleDo.Core.Enums;

namespace ToodleDo.Core.IRepositories
{
    public interface IToDoItemRepository : IRepository<ToDoItem>
    {
        IEnumerable<ToDoItem> GetHighPriorityItems(Priority priority);
        IEnumerable<ToDoItem> GetCriticalPriorityItems(Priority priority);
        IEnumerable<ToDoItem> GetItemWithOwner(int pageIndex, int pageSize);
    }
}