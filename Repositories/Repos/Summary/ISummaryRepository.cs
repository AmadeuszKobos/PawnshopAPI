using Entities.Summary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
  public interface ISummaryRepository : IBaseRepository<Summary>
  {
    List<Summary> GetSummariesByDateRange(DateTime startDate, DateTime endDate, int? userId = null);
  }
}