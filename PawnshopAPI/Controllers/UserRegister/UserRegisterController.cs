using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI
{
  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
  [ApiController]
  public class UserRegisterController : Controller
  {
    private readonly IUserRegisterService _userRegisterService;

    public UserRegisterController(IUserRegisterService userRegisterService)
    {
      _userRegisterService = userRegisterService;
    }

    [HttpGet]
    [Route("GetUsersRegister")]
    public IActionResult GetUsersRegister()
    {
      try
      {
        var userClaimId = int.TryParse(User.FindFirst("Id")?.Value, out int userId);

        if (userId == 1)
        {
          var users = _userRegisterService.GetUsersRegister();

          return Ok(users);
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}