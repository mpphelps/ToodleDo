using System;
using ToodleDo.Core.IRepositories;

namespace ToodleDo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOwnerRepository Owners { get; }
        IToDoItemRepository ToDoItems { get; }
        int Complete();
    }
}