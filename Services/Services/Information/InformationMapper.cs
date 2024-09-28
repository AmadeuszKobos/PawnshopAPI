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
    public static List<InformationVm> Map(IQueryable<Information> en)
    {
      var list = en.Select(e => new InformationVm()
      {
        Type = e.Type,
        Content = e.Content,
      }).ToList();

      return list;
    }
  }
}