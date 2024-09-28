using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static List<ItemHistoryRegisterVm> Map(IEnumerable<ItemHistoryRegister> entities)
    {
      var list = entities.Select(e => new ItemHistoryRegisterVm
      {
        OperationDate = e.OperationDate,
        OperationId = e.OperationId,
        ConditionId = e.ConditionId,
        TransactionAmount = e.TransactionAmount,
        Notes = e.Notes,
        Person = e.Person,
        ItemId = e.ItemId,
        ItemName = e.ItemName,
        Username = e.Username,
      }).ToList();

      return list;
    }
  }
}