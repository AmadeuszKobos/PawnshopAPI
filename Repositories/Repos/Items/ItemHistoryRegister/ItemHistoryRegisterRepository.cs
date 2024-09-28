using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class ItemHistoryRegisterRepository : BaseRepository<ItemHistoryRegister>, IItemHistoryRegisterRepository
  {
    public ItemHistoryRegisterRepository(AppDbContext context) : base(context)
    {
    }
  }
}