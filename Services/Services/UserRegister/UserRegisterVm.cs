using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UserRegisterVm
  {
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public bool Blocked { get; set; }
  }
}