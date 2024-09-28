using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class PersonRepository : BaseRepository<Person>, IPersonRepository
  {
    public PersonRepository(AppDbContext context) : base(context)
    {
    }
  }
}