using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class PersonRegisterController : Controller
  {
    private IPersonRegisterService _personRegisterService;

    public PersonRegisterController(IPersonRegisterService personRegisterService)
    {
      _personRegisterService = personRegisterService;
    }

    [HttpGet]
    [Route("GetPersonRegister")]
    public ActionResult GetPersonRegister()
    {
      try
      {
        var personRegister = _personRegisterService.GetPersonRegister();

        return Ok(personRegister);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}