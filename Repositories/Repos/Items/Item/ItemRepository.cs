using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class ItemRepository : BaseRepository<Item>, IItemRepository
  {
    public ItemRepository(AppDbContext context) : base(context)
    {
    }
  }
}