using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ItemStatusVm
  {
    public int? StatusId { get; set; }
    public string StatusName { get; set; } = "";
    public string StatusDescription { get; set; } = "";
  }
}