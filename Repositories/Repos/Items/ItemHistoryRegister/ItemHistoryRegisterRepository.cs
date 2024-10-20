using Entities;

namespace Repositories
{
  public class ItemHistoryRegisterRepository : BaseRepository<ItemHistoryRegister>, IItemHistoryRegisterRepository
  {
    public ItemHistoryRegisterRepository(AppDbContext context) : base(context)
    {
    }
  }
}