using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("ItemsHistoryRegister")]
  public class ItemHistoryRegister
  {
    [Key]
    [Column("ItemHistoryId")]
    public int ItemHistoryId { get; set; }

    [Column("OperationDate")]
    public DateTime OperationDate { get; set; }

    [Column("OperationId")]
    public int OperationId { get; set; }

    [Column("TransactionAmount")]
    public decimal TransactionAmount { get; set; }

    [Column("ConditionId")]
    public int ConditionId { get; set; }

    [Column("Notes")]
    public string Notes { get; set; } = string.Empty;

    [Column("PersonId")]
    public int PersonId { get; set; }

    [Column("Person")]
    public string Person { get; set; } = string.Empty;

    [Column("ItemId")]
    public int ItemId { get; set; }

    [Column("ItemName")]
    public string ItemName { get; set; } = string.Empty;

    [Column("UserId")]
    public int UserId { get; set; }

    [Column("Username")]
    public string Username { get; set; } = string.Empty;
  }
}