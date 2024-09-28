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
  public class ItemService : IItemService
  {
    private readonly IItemRepository _repo;
    private readonly IItemHistoryRepository _itemHistoryRepo;
    private readonly IItemHistoryService _itemHistoryService;

    public ItemService(IItemRepository repo, IItemHistoryService itemHistoryService, IItemHistoryRepository itemHistoryRepo)
    {
      _repo = repo;
      _itemHistoryRepo = itemHistoryRepo;
      _itemHistoryService = itemHistoryService;
    }

    public ItemVm GetItem(int itemId)
    {
      var item = _repo.FirstOrDefault(x => x.Id == itemId);
      var itemVm = Mapper.Map(item);
      return itemVm;
    }

    public void AddOrUpdateItem(ItemVm itemVm)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      var item = Mapper.Map(itemVm);

      if (itemVm.History.OperationId == (int)OperationTypeEnum.Pawn)
        item.PawnshopOwnershipDate = DateTime.Now.AddDays(itemVm.Days);

      if (itemVm.History.OperationId == (int)OperationTypeEnum.Extension)
        item.PawnshopOwnershipDate = item.PawnshopOwnershipDate?.AddDays(itemVm.Days);

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _repo.AddOrUpdate(item.Id, item);

        var itemHistory = Mapper.Map(itemVm.History, item.Id);

        _itemHistoryService.AddItemHistory(itemHistory);

        tran.Complete();
      }
    }

    public void UpdateItemSellOrHandover(ItemForSaleVm itemForSaleVm, OperationTypeEnum operation)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _repo.UpdateSingleColumn<DateTime?>(x => x.Id == itemForSaleVm.ItemId, x => x.PawnshopOwnershipDate, null);

        var itemHistory = Mapper.Map(itemForSaleVm, itemForSaleVm.ItemId, (int)operation);

        if (operation == OperationTypeEnum.Handover)
        {
          itemHistory.Notes = "Towar wydany";
        }
        else
        {
          itemHistory.Notes = "Towar sprzedany";
        }

        _itemHistoryService.AddItemHistory(itemHistory);

        tran.Complete();
      }
    }

    public void UpdateItemDelete(int itemId)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _repo.UpdateSingleColumn<bool?>(x => x.Id == itemId, x => x.Deleted, true);

        var itemHistory = Mapper.Map(itemId);

        _itemHistoryService.AddItemHistory(itemHistory);

        tran.Complete();
      }
    }
  }
}