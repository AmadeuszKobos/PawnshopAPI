using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemRegisterVm
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public ItemStatusVm ItemStatus { get; set; } = new ItemStatusVm();
    public DateTime LastModificationDate { get; set; }
    public int? ConditionId { get; set; }
    public string Condition { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime? PawnshopOwnershipDate { get; set; }
  }
}