﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(AppDbContext context) : base(context)
    {
    }
  }
}