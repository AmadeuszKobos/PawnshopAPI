using Entities;

namespace Repositories
{
  public class AddressRepository : BaseRepository<Address>, IAddressRepository
  {
    public AddressRepository(AppDbContext context) : base(context)
    {
    }
  }
}