using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UserRegisterService : IUserRegisterService
  {
    private readonly IUserRegisterRepository _userRegisterRepo;

    public UserRegisterService(IUserRegisterRepository userRegisterRepository)
    {
      _userRegisterRepo = userRegisterRepository;
    }

    public List<UserRegisterVm> GetUsersRegister()
    {
      return Mapper.Map(_userRegisterRepo.GetAll());
    }
  }
}