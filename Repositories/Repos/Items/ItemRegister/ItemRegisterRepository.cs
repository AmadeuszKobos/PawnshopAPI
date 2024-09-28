using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class ItemRegisterRepository : BaseRepository<ItemRegister>, IItemRegisterRepository
  {
    public ItemRegisterRepository(AppDbContext context) : base(context)
    {
    }
  }
}