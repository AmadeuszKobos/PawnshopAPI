using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IPersonService
  {
    PersonVm GetPerson(int personId);
    PersonVm GetPersonForItem(int itemId);
    List<PersonForSearchVm> GetPersonsForSearch(string searchValue);
    PersonVm AddOrUpdatePerson(PersonVm personVm);
    void UpdateBlacklistFlag(int personId, bool currentBlacklistFlag);
  }
}