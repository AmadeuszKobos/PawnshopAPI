using Entities.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
  public interface ISummaryService
  {
    List<Summary> GetSummariesByDateRange(DateTime startDate, DateTime endDate, int? userId = null);
  }
}