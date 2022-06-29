using ToodleDo.Core;
using ToodleDo.Core.IRepositories;
using ToodleDo.DataAccess.Repositories;

namespace ToodleDo.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext _context;

        public UnitOfWork(ToDoContext toDoContext)
        {
            _context = toDoContext;
            ToDoItems = new ToDoItemRepository(_context);
            Owners = new OwnerRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IOwnerRepository Owners { get; private set; }
        public IToDoItemRepository ToDoItems { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        
    }
}