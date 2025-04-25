using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static List<UserRegisterVm> Map(IQueryable<UsersRegister> entities)
    {
      var list = entities.Select(e => new UserRegisterVm
      {
        UserId = e.UserId,
        Username = e.Username,
        Name = e.Name,
        PhoneNumber = e.PhoneNumber,
        Blocked = e.Blocked,
        LastLogin = e.LastLogin,
      }).ToList();

      return list;
    }
  }
}