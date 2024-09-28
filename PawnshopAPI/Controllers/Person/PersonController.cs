using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PawnshopAPI.Controllers
{
  [Route("[controller]")]
  [Authorize(Roles = "User")]
  [ApiController]
  public class PersonController : Controller
  {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
      _personService = personService;
    }

    [HttpGet]
    [Route("GetPerson")]
    public IActionResult GetPerson(int personId)
    {
      try
      {
        var persons = _personService.GetPerson(personId);

        return Ok(persons);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetPersonsForSearch")]
    public IActionResult GetPersonsForSearch(string searchValue)
    {
      try
      {
        var persons = _personService.GetPersonsForSearch(searchValue);

        return Ok(persons);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetPersonForItem")]
    public IActionResult GetPersonForItem(int itemId)
    {
      try
      {
        var person = _personService.GetPersonForItem(itemId);

        return Ok(person);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("AddOrUpdatePerson")]
    public IActionResult AddOrUpdatePerson(PersonVm personVm)
    {
      try
      {
        var responseVm = _personService.AddOrUpdatePerson(personVm);

        return Ok(responseVm);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UpdateBlacklistFlag")]
    public IActionResult UpdateBlacklistFlag(PersonBlacklistVm personBlacklistVm)
    {
      try
      {
        _personService.UpdateBlacklistFlag(personBlacklistVm.PersonId, personBlacklistVm.CurrentBlacklistFlag);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}