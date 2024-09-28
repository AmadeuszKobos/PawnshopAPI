using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public partial class Mapper
  {
    public static ItemRegisterVm Map(ItemRegister entity)
    {
      var vm = new ItemRegisterVm()
      {
        Id = entity.Id,
        Name = entity.Name,
        Producer = entity.Producer,
        ItemStatus = new ItemStatusVm
        {
          StatusId = entity.StatusId,
          StatusName = entity.StatusName,
          StatusDescription = entity.StatusDescription,
        },
        LastModificationDate = entity.LastModificationDate,
        ConditionId = entity.ConditionId,
        Condition = entity.Condition,
        Notes = entity.Notes,
        PawnshopOwnershipDate = entity.PawnshopOwnershipDate,
      };

      return vm;
    }

    public static List<ItemRegisterVm> Map(IEnumerable<ItemRegister> entities)
    {
      var list = entities.Select(e => new ItemRegisterVm
      {
        Id = e.Id,
        Name = e.Name,
        Producer = e.Producer,
        ItemStatus = new ItemStatusVm
        {
          StatusId = e.StatusId,
          StatusName = e.StatusName,
          StatusDescription = e.StatusDescription,
        },
        LastModificationDate = e.LastModificationDate,
        ConditionId = e.ConditionId,
        Condition = e.Condition,
        Notes = e.Notes,
        PawnshopOwnershipDate= e.PawnshopOwnershipDate,
      }).ToList();

      return list;
    }
  }
}