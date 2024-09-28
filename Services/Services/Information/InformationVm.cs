using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class InformationVm
  {
    public int Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
  }
}