using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static Address Map(AddressVm vm)
    {
      var en = new Address()
      {
        AddressId = vm.AddressId,
        Street = vm.Street,
        City = vm.City,
        PostalCode = vm.PostalCode,
        Country = vm.Country,
      };

      return en;
    }

    public static AddressVm Map(Address en)
    {
      var vm = new AddressVm()
      {
        AddressId = en.AddressId,
        Street = en.Street,
        City = en.City,
        PostalCode = en.PostalCode,
        Country = en.Country,
      };

      return vm;
    }
  }
}