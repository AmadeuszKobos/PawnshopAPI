using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI.Controllers
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class InformationController : Controller
  {
    private readonly IInformationService _informationService;

    public InformationController(IInformationService informationService)
    {
      _informationService = informationService;
    }

    [HttpGet]
    [Route("GetInformations")]
    public IActionResult GetInformations()
    {
      try
      {
        var informations = _informationService.GetInformations();

        return Ok(informations);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetLastInformations")]
    public IActionResult GetLastInformations()
    {
      try
      {
        var informations = _informationService.GetLastInformations();

        return Ok(informations);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}