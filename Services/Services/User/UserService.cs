using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Azure.Core.HttpHeader;

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

    public void AddUser(UserVm user)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _userRepository.AddOrUpdate(0, Mapper.Map(user));

        tran.Complete();
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

    public void UpdateUserPassword(UserPasswordVm userPass)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _userRepository.UpdateSingleColumn(x => x.UserId == userPass.UserId, x => x.Password, userPass.Password);

        var previousPassword = _userRepository.FirstOrDefault(x => x.UserId == userPass.UserId).Password;

        _userRepository.UpdateSingleColumn(x => x.UserId == userPass.UserId, x => x.PreviousPassword, previousPassword);

        tran.Complete();
      }
    }

    public void UpdateUserBlockState(int userId, bool currentBlockState)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _userRepository.UpdateSingleColumn(x => x.UserId == userId, x => x.Blocked, !currentBlockState);

        tran.Complete();
      }
    }

    public void DeleteUser(int userId)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _userRepository.UpdateSingleColumn(x => x.UserId == userId, x => x.Deleted, true);

        tran.Complete();
      }
    }
  }
}