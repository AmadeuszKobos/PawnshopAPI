using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
  public interface IPersonRepository : IBaseRepository<Person>
  {
    IQueryable<Person> GetPersonsForSearch(string searchValue)
    {
      searchValue = searchValue.ToLower();

      return GetAll().Where(x =>
                                  (x.PersonId.ToString().Contains(searchValue) ||
                                  x.Name.ToLower().Contains(searchValue) ||
                                  x.Surname.ToLower().Contains(searchValue) ||
                                  x.PersonalNumber.ToLower().Contains(searchValue) ||
                                  x.PhoneNumber.ToLower().Contains(searchValue) ||
                                  x.EmailAddress.ToLower().Contains(searchValue)) &&
                                  !x.BlackListFlag
                           );
    }
  }
}