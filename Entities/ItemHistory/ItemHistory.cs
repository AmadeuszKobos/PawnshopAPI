using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("ItemsHistories")]
  public class ItemHistory
  {
    [Column("ItemHistoryId")]
    public int Id { get; set; }

    [Column("OperationDate")]
    public DateTime OperationDate { get; set; }

    [Column("TransactionAmount")]
    public decimal TransactionAmount { get; set; }

    [Column("Notes")]
    public string Notes { get; set; } = string.Empty;

    [Column("ConditionStatusId")]
    public int ConditionStatusId { get; set; }

    [Column("ItemId")]
    public int ItemId { get; set; }

    [Column("UserId")]
    public int UserId { get; set; }

    [Column("PersonId")]
    public int PersonId { get; set; }

    [Column("OperationTypeId")]
    public int OperationTypeId { get; set; }
  }
}