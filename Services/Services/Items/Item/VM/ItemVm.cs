using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemVm
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Producer { get; set; } = string.Empty;

    //public int Picture { get; set; }

    public int Days { get; set; }

    public DateTime? PawnshopOwnershipDate { get; set; }

    public ItemHistoryVm History { get; set; } = new ItemHistoryVm();
  }
}