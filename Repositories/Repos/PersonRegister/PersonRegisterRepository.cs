using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class PersonRegisterRepository : BaseRepository<PersonRegister>, IPersonRegisterRepository
  {
    public PersonRegisterRepository(AppDbContext context) : base(context)
    {
    }
  }
}