using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI.Controllers
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class ItemController : Controller
  {
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
      _itemService = itemService;
    }

    [HttpPost]
    [Route("AddOrUpdateItem")]
    public IActionResult AddOrUpdateItem(ItemVm itemVm)
    {
      try
      {
        _itemService.AddOrUpdateItem(itemVm);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateItemSell")]
    public IActionResult UpdateItemSell(ItemForSaleVm itemVm)
    {
      try
      {
        _itemService.UpdateItemSellOrHandover(itemVm, Repositories.ENUM.OperationTypeEnum.Sale);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateItemHandover")]
    public IActionResult UpdateItemHandover(ItemForSaleVm itemId)
    {
      try
      {
        _itemService.UpdateItemSellOrHandover(itemId, Repositories.ENUM.OperationTypeEnum.Handover);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateItemDelete")]
    public IActionResult UpdateItemDelete([FromBody] int itemId)
    {
      try
      {
        _itemService.UpdateItemDelete(itemId);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}