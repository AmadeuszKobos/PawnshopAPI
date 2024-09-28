using Entities;
using Repositories.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static ItemVm Map(Item en)
    {
      var vm = new ItemVm()
      {
        Id = en.Id,
        Name = en.Name,
        Producer = en.Producer,
        PawnshopOwnershipDate = en.PawnshopOwnershipDate,
      };

      return vm;
    }

    public static Item Map(ItemVm vm)
    {
      var en = new Item()
      {
        Id = vm.Id,
        Name = vm.Name,
        Producer = vm.Producer,
        //todo: picture
        PawnshopOwnershipDate = vm.Id == 0 ? DateTime.Now : vm.PawnshopOwnershipDate,
      };

      return en;
    }

    public static ItemHistory Map(ItemForSaleVm itemVm, int itemId, int operationId)
    {
      var itemHistory = new ItemHistory()
      {
        OperationDate = DateTime.Now,
        TransactionAmount = itemVm.TransactionAmount,
        ConditionStatusId = 0,
        ItemId = itemId,
        PersonId = itemVm.PersonId,
        OperationTypeId = operationId
      };

      return itemHistory;
    }

    public static ItemHistory Map(int itemId)
    {
      var itemHistory = new ItemHistory()
      {
        OperationDate = DateTime.Now,
        TransactionAmount = 0,
        Notes = "Usunięty",
        ConditionStatusId = 0,
        ItemId = itemId,
        PersonId = 0,
        OperationTypeId = (int)OperationTypeEnum.Delete,
      };

      return itemHistory;
    }
  }
}