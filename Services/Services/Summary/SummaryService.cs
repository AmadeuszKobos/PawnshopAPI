using Entities.Summary;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
  public class SummaryService : ISummaryService
  {
    private readonly ISummaryRepository _summaryRepo;

    public SummaryService(ISummaryRepository summaryRepo)
    {
      _summaryRepo = summaryRepo;
    }

    public List<Summary> GetSummariesByDateRange(DateTime startDate, DateTime endDate, int? userId = null)
    {
      return _summaryRepo.GetSummariesByDateRange(startDate, endDate, userId);
    }
  }
}