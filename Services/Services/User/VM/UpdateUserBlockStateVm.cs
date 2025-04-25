using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UpdateUserBlockStateVm
  {
    public int UserId { get; set; }
    public bool CurrentBlockState { get; set; }
  }
}
