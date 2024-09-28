using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public UserVm GetUserByLogin(LoginVm login)
    {
      var user = _userRepository.FirstOrDefault(x => x.Username == login.Username);

      if (user == null)
        throw new Exception("user_not_found");

      var userVm = Mapper.Map(user);

      if (user.Password == login.Password)
      {
        return userVm;
      }
      else if (user.PreviousPassword == login.Password)
      {
        throw new Exception("old_password");
      }
      else
      {
        throw new Exception("incorrect_password");
      }
    }

    public string GetUserNotes(int userId)
    {
      return _userRepository.FirstOrDefault(x => x.UserId == userId).Notes;
    }

    public void UpdateUserNotes(int userId, string notes)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _userRepository.UpdateSingleColumn(x => x.UserId == userId, x => x.Notes, notes);

        tran.Complete();
      }
    }
  }
}