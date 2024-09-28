using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class AddressRepository : BaseRepository<Address>, IAddressRepository
  {
    public AddressRepository(AppDbContext context) : base(context)
    {
    }
  }
}