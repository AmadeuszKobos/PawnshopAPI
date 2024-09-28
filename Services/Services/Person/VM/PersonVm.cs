using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class PersonVm
  {
    public int PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PersonalNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public bool BlackListFlag { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Notes { get; set; } = string.Empty;

    public int? AddressId { get; set; }
    public AddressVm Address { get; set; } = new AddressVm();
  }
}