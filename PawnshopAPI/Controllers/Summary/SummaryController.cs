using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace PawnshopAPI.Controllers.Summary
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class SummaryController : Controller
  {
    private readonly ISummaryService _summaryService;

    public SummaryController(ISummaryService summaryService)
    {
      _summaryService = summaryService;
    }

    [HttpGet]
    [Route("GetSummariesByDateRange")]
    public IActionResult GetSummariesByDateRange(DateTime startDate, DateTime endDate, bool getAll)
    {
      try
      {
        int? userId = null;

        if (!getAll)
        {
          if (int.TryParse(User.FindFirst("Id")?.Value, out int parsedUserId))
          {
            userId = parsedUserId;
          }
          else
          {
            return Unauthorized("Pobieranie dla zalogowanego użytkownika nie jest możliwe");
          }
        }

        var summaries = _summaryService.GetSummariesByDateRange(startDate, endDate, userId);

        return Ok(summaries);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}