using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static ItemHistory Map(ItemHistoryVm itemHistoryVm, int itemId)
    {
      var itemHistory = new ItemHistory()
      {
        OperationDate = DateTime.Now,
        TransactionAmount = itemHistoryVm.TransactionAmount,
        Notes = itemHistoryVm.Notes,
        ConditionStatusId = itemHistoryVm.ConditionId,
        ItemId = itemId,
        PersonId = itemHistoryVm.PersonId,
        OperationTypeId = itemHistoryVm.OperationId,
      };

      return itemHistory;
    }

    public static List<ItemHistoryVm> Map(IEnumerable<ItemHistory> entities)
    {
      var list = entities.Select(e => new ItemHistoryVm
      {
        Id = e.Id,
        OperationDate = e.OperationDate,
        OperationId = e.OperationTypeId,
        ConditionId = e.ConditionStatusId,
        TransactionAmount = e.TransactionAmount,
        Notes = e.Notes,
        UserId = e.UserId,
        PersonId = e.PersonId,
      }).ToList();

      return list;
    }
  }
}