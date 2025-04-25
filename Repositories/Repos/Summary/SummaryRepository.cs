using Entities.Summary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
  public class SummaryRepository : BaseRepository<Summary>, ISummaryRepository
  {
    public SummaryRepository(AppDbContext context) : base(context)
    {
    }

    public List<Summary> GetSummariesByDateRange(DateTime startDate, DateTime endDate, int? userId = null)
    {
      return _context.Summaries
          .FromSqlInterpolated($@"
                SELECT *
                FROM dbo.GetSummariesByDateRange({startDate}, {endDate}, {userId}) AS i")
          .ToList();
    }
  }
}