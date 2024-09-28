using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemForSaleVm
  {
    public int PersonId { get; set; }
    public int ItemId { get; set; }
    public decimal TransactionAmount { get; set; }
  }
}