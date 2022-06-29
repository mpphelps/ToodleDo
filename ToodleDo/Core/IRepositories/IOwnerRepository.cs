using ToodleDo.Core.Entities;

namespace ToodleDo.Core.IRepositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Owner GetOwnerWithItems(int Id);
    }
}