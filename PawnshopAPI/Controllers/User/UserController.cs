using HomeAPI.DI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PawnshopAPI.Controllers.User
{
  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    [Route("GetToken"), AllowAnonymous]
    public IActionResult GetToken(LoginVm loginVm)
    {
      var token = "";
      var user = new UserVm();

      try
      {
        if (loginVm.Username != null && loginVm.Password != null)
        {
          user = _userService.GetUserByLogin(loginVm);
          token = TokenManager.GenerateToken(user);
        }

        return Ok(token);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetUserNotes")]
    public IActionResult GetUserNotes()
    {
      try
      {
        var userClaimId = int.TryParse(User.FindFirst("Id")?.Value, out int userId);

        var notes = _userService.GetUserNotes(userId);

        return Ok(notes);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateUserNotes")]
    public IActionResult UpdateUserNotes(string notes)
    {
      try
      {
        var userClaimId = int.TryParse(User.FindFirst("Id")?.Value, out int userId);

        _userService.UpdateUserNotes(userId, notes);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}