using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemHistoryVm
  {
    public int Id { get; set; }

    public DateTime OperationDate { get; set; }

    public int OperationId { get; set; }

    public int ConditionId { get; set; }

    public decimal TransactionAmount { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ItemId { get; set; }

    public int UserId { get; set; }

    public int PersonId { get; set; }
  }
}