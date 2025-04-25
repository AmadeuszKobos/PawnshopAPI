using Entities;

namespace Repositories
{
  public class PersonRepository : BaseRepository<Person>, IPersonRepository
  {
    public PersonRepository(AppDbContext context) : base(context)
    {
    }
  }
}