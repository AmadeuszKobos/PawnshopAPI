using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IItemRegisterService
  {
    ItemRegisterVm GetItem(int itemId);
    List<ItemRegisterVm> GetItems();
  }
}