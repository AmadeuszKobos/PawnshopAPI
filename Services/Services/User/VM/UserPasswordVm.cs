using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UserPasswordVm
  {
    public int UserId { get; set; }
    public string Password { get; set; }  
    public string PreviousPassword { get; set; }
  }
}
