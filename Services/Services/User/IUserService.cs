using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Services
{
  public interface IUserService
  {
    UserVm GetUserByLogin(LoginVm login);
    string GetUserNotes(int userId);
    void UpdateUserNotes(int userId, string notes);
  }
}