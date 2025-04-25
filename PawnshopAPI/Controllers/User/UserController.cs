using HomeAPI.DI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Azure.Identity;

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

        var notes = _userService.GetUserNotes(userId) ?? string.Empty;  // Ensure notes are never null
        return Ok(new { Notes = notes });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("AddUser")]
    public IActionResult AddUser(UserVm user)
    {
      try
      {
        if (user == null)
          throw new Exception("empty_model");

        if (user.PersonId == 0 || user.PersonId == null)
          throw new Exception("missing_person_id");

        _userService.AddUser(user);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateUserNotes")]
    public IActionResult UpdateUserNotes(StringTypeBody notes)
    {
      try
      {
        var userClaimId = int.TryParse(User.FindFirst("Id")?.Value, out int userId);

        _userService.UpdateUserNotes(userId, notes.Text);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateUserPassword")]
    public IActionResult UpdateUserPassword(UserPasswordVm userPass)
    {
      try
      {
        if (userPass == null)
          throw new Exception("user_not_passed");

        _userService.UpdateUserPassword(userPass);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateUserBlockState")]
    public IActionResult UpdateUserBlockState([FromBody] UpdateUserBlockStateVm updUserBlockState)
    {
      try
      {
        _userService.UpdateUserBlockState(updUserBlockState.UserId, updUserBlockState.CurrentBlockState);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("DeleteUser")]
    public IActionResult DeleteUser(int userId)
    {
      try
      {
        _userService.DeleteUser(userId);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}