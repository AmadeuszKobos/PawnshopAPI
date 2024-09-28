using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class ItemHistoryRepository : BaseRepository<ItemHistory>, IItemHistoryRepository
  {
    public ItemHistoryRepository(AppDbContext context) : base(context)
    {
    }
  }
}