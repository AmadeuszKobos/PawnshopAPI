using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class PersonRegisterService : IPersonRegisterService
  {
    private IPersonRegisterRepository _repo;

    public PersonRegisterService(IPersonRegisterRepository repo)
    {
      _repo = repo;
    }

    public List<PersonRegisterVm> GetPersonRegister()
    {
      return Mapper.Map(_repo.GetAll());
    }
  }
}