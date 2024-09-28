using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UserVm
  {
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? PreviousPassword { get; set; }

    public DateTime? LastLogin { get; set; }

    public bool Blocked { get; set; }

    public int? PersonId { get; set; }

    public int? RightId { get; set; }
  }
}