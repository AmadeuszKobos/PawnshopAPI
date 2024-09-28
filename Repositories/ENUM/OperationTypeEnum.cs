using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ENUM
{
  public enum OperationTypeEnum // Operation types equals item status types
  {
    All = 0,
    Purchase = 1,
    Sale = 2,
    Pawn = 3,
    Handover = 4,
    Extension = 5,
    Update = 6,
    Delete = 7,
  }
}