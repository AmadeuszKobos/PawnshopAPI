using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemHistoryRegisterVm
  {
    public DateTime OperationDate { get; set; }

    public int OperationId { get; set; }

    public decimal TransactionAmount { get; set; }

    public int ConditionId { get; set; }

    public string Notes { get; set; } = string.Empty;

    public string Person { get; set; } = string.Empty;

    public int ItemId { get; set; }

    public string ItemName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;
  }
}