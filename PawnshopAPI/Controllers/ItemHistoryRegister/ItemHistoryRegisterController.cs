using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI.Controllers.ItemHistoryRegister
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class ItemHistoryRegisterController : Controller
  {
    private readonly IItemHistoryRegisterService _service;

    public ItemHistoryRegisterController(IItemHistoryRegisterService service)
    {
      _service = service;
    }

    [HttpGet]
    [Route("GetItemHistory")]
    public IActionResult GetItemHistory(int itemId)
    {
      try
      {
        if (itemId == 0)
          throw new Exception("missing_id");

        var itemHistories = _service.GetItemHistoryRegister(itemId);

        if (itemHistories == null)
        {
          return NotFound();
        }

        return Ok(itemHistories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetPersonItemHistory")]
    public IActionResult GetPersonItemHistory(int personId)
    {
      try
      {
        if (personId == 0)
          throw new Exception("missing_id");

        var itemHistories = _service.GetPersonItemHistoryRegister(personId);

        if (itemHistories == null)
        {
          return NotFound();
        }

        return Ok(itemHistories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetUserLastModificatedItemsHistory")]
    public IActionResult GetUserLastModificatedItemsHistory()
    {
      try
      {
        var userClaimId = int.TryParse(User.FindFirst("Id")?.Value, out int userId);

        var itemsModified = _service.GetUserLastModificatedItemsHistory(userId);

        return Ok(itemsModified);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}