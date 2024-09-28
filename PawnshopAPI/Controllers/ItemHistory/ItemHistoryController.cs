using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class ItemHistoryController : Controller
  {
    private IItemHistoryService _itemHistoryService;

    public ItemHistoryController(IItemHistoryService itemHistoryService)
    {
      _itemHistoryService = itemHistoryService;
    }

    [HttpGet]
    [Route("GetItemPriceSuggestion")]
    public IActionResult GetItemPriceSuggestion(int itemId, DateTime pawnshopOwnershipDate)
    {
      try
      {
        var priceSuggestion = _itemHistoryService.GetItemPriceSuggestion(itemId, pawnshopOwnershipDate);

        return Ok(priceSuggestion);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetItemHistory")]
    public IActionResult GetItemHistory(int itemId)
    {
      try
      {
        if (itemId == 0)
          throw new Exception("missing_id");

        var itemHistories = _itemHistoryService.GetItemHistory(itemId);

        if (itemHistories == null)
        {
          return NotFound();
        }

        return Ok(itemHistories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
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

        var itemHistories = _itemHistoryService.GetPersonItemHistory(personId);

        if (itemHistories == null)
        {
          return NotFound();
        }

        return Ok(itemHistories);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}