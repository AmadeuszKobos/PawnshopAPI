using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class UserRegisterRepository : BaseRepository<UsersRegister>, IUserRegisterRepository
  {
    public UserRegisterRepository(AppDbContext context) : base(context)
    {
    }
  }
}