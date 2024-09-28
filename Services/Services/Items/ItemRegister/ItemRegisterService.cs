using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemRegisterService : IItemRegisterService
  {
    private readonly IItemRegisterRepository _itemRegisterRepo;

    public ItemRegisterService(IItemRegisterRepository itemRegisterRepo)
    {
      _itemRegisterRepo = itemRegisterRepo;
    }

    public ItemRegisterVm GetItem(int itemId)
    {
      return Mapper.Map(_itemRegisterRepo.FirstOrDefault(x => x.Id == itemId));
    }

    public List<ItemRegisterVm> GetItems()
    {
      return Mapper.Map(_itemRegisterRepo.GetAll());
    }
  }
}