using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemHistoryRegisterService : IItemHistoryRegisterService
  {
    private readonly IItemHistoryRegisterRepository _repo;

    public ItemHistoryRegisterService(IItemHistoryRegisterRepository repo)
    {
      _repo = repo;
    }

    public List<ItemHistoryRegisterVm> GetItemHistoryRegister(int itemId)
    {
      return Mapper.Map(_repo.GetAll().Where(x => x.ItemId == itemId));
    }

    public List<ItemHistoryRegisterVm> GetPersonItemHistoryRegister(int personId)
    {
      return Mapper.Map(_repo.GetAll().Where(x => x.PersonId == personId));
    }
  }
}