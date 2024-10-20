using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Summary
{
  public class Summary
  {
    public int OperationId { get; set; }
    public int TotalOperationsAmount { get; set; }  
    public decimal TotalTransactionAmount { get; set; }  
  }
}