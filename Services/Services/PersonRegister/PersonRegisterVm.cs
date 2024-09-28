using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class PersonRegisterVm
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; } = string.Empty;

    public bool BlacklistFlag { get; set; }

    public int Pawned { get; set; }

    public string Notes { get; set; } = string.Empty;
  }
}