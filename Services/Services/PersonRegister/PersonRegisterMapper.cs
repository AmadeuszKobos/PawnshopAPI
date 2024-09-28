using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static List<PersonRegisterVm> Map(IQueryable<PersonRegister> entities)
    {
      var list = entities.Select(e => new PersonRegisterVm
      {
        Id = e.Id,
        Name = e.Name,
        Email = e.Email,
        PhoneNumber = e.PhoneNumber,
        BlacklistFlag = e.BlacklistFlag,
        Pawned = e.Pawned,
        Notes = e.Notes,
      }).ToList();

      return list;
    }
  }
}