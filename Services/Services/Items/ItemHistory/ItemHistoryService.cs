using Entities;
using Repositories;
using Repositories.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
  public class ItemHistoryService : IItemHistoryService
  {
    private readonly IItemHistoryRepository _repo;

    public ItemHistoryService(IItemHistoryRepository repo)
    {
      _repo = repo;
    }

    public List<ItemHistoryVm> GetItemHistory(int itemId)
    {
      return Mapper.Map(_repo.GetAll().Where(x => x.ItemId == itemId));
    }

    public List<ItemHistoryVm> GetPersonItemHistory(int personId)
    {
      return Mapper.Map(_repo.GetAll().Where(x => x.PersonId == personId));
    }

    public decimal GetItemPriceSuggestion(int itemId, DateTime? pawnshopOwnershipDate) //todo: zrobić mądrzej
    {
      var itemLastAddHistory = _repo.OrderByDescending(x => x.OperationDate).FirstOrDefault(x => x.ItemId == itemId && (x.OperationTypeId == (int)OperationTypeEnum.Pawn || x.OperationTypeId == (int)OperationTypeEnum.Purchase));

      if (itemLastAddHistory == null)
        throw new Exception("Nie znaleziono ceny wydanej przez lombard");

      if (pawnshopOwnershipDate == null)
      {
        throw new ArgumentException("Przedmiot już został sprzedany lub wydany");
      }

      if (pawnshopOwnershipDate <= DateTime.Now)
      {
        return itemLastAddHistory.TransactionAmount;
      }
      else
      {
        var diffrence = DateTime.Now - itemLastAddHistory.OperationDate;

        return (itemLastAddHistory.TransactionAmount + 10 + (diffrence.Days * itemLastAddHistory.TransactionAmount * 5 / 1000));
      }
    }

    public void AddItemHistory(ItemHistory itemHistory)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _repo.AddOrUpdate(itemHistory.Id, itemHistory);

        tran.Complete();
      }
    }


  }
}