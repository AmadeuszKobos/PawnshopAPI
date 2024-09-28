using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI.Controllers
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class ItemRegisterController : Controller
  {
    private readonly IItemRegisterService _itemRegisterService;

    public ItemRegisterController(IItemRegisterService itemRegisterService)
    {
      _itemRegisterService = itemRegisterService;
    }

    [HttpGet]
    [Route("GetItem")]
    public IActionResult GetItem(int itemId)
    {
      try
      {
        if (itemId == 0)
          throw new Exception("missing_id");

        var item = _itemRegisterService.GetItem(itemId);

        if (item == null)
        {
          return NotFound();
        }

        return Ok(item);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpGet]
    [Route("GetItems")]
    public IActionResult GetItems()
    {
      try
      {
        var item = _itemRegisterService.GetItems();

        if (item == null)
        {
          return NotFound();
        }

        return Ok(item);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}