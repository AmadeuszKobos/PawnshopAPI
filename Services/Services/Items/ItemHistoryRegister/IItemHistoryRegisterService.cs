using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IItemHistoryRegisterService
  {
    public List<ItemHistoryRegisterVm> GetItemHistoryRegister(int itemId);

    public List<ItemHistoryRegisterVm> GetPersonItemHistoryRegister(int personId);
  }
}