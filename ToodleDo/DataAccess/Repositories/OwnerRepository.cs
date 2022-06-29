using System.Data.Entity;
using System.Linq;
using ToodleDo.Core.Entities;
using ToodleDo.Core.IRepositories;

namespace ToodleDo.DataAccess.Repositories
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DbContext context) : base(context)
        {
        }

        public Owner GetOwnerWithItems(int Id)
        {
            return ToDoContext.Owners.Include(o => o.ToDoItems).SingleOrDefault(o => o.Id == Id);
        }

        public ToDoContext ToDoContext
        {
            get { return Context as ToDoContext; }
        }
    }
}