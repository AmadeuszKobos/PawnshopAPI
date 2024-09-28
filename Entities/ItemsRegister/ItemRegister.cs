using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("ItemsRegister")]
  public class ItemRegister
  {
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = "";

    [Column("Producer")]
    public string Producer { get; set; } = "";

    [Column("StatusId")]
    public int? StatusId { get; set; }

    [Column("StatusName")]
    public string? StatusName { get; set; } = "";

    [Column("StatusDescription")]
    public string? StatusDescription { get; set; } = "";

    [Column("LastModificationDate")]
    public DateTime LastModificationDate { get; set; }

    [Column("ConditionId")]
    public int? ConditionId { get; set; }

    [Column("Condition")]
    public string? Condition { get; set; } = "";

    [Column("Notes")]
    public string? Notes { get; set; } = "";

    [Column("PawnshopOwnershipDate")]
    public DateTime? PawnshopOwnershipDate { get; set; }
  }
}