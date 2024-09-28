using Entities;
using Repositories.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IItemHistoryService
  {
    public decimal GetItemPriceSuggestion(int itemId, DateTime? pawnshopOwnershipDate);

    public List<ItemHistoryVm> GetItemHistory(int itemId);

    public List<ItemHistoryVm> GetPersonItemHistory(int personId);

    public void AddItemHistory(ItemHistory item);
  }
}