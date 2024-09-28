using Entities;
using Repositories.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IItemService
  {
    ItemVm GetItem(int itemId);

    void AddOrUpdateItem(ItemVm itemVm);

    void UpdateItemSellOrHandover(ItemForSaleVm itemVm, OperationTypeEnum operation);

    void UpdateItemDelete(int itemId);
  }
}