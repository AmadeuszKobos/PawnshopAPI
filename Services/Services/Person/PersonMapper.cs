using Entities;

namespace Services
{
  public partial class Mapper
  {
    public static List<PersonVm> Map(IQueryable<Person> en)
    {
      var list = en.Select(e => new PersonVm()
      {
        PersonId = e.PersonId,
        Name = e.Name,
        Surname = e.Surname,
        PersonalNumber = e.PersonalNumber,
        EmailAddress = e.EmailAddress,
        BlackListFlag = e.BlackListFlag,
        RegistrationDate = e.RegistrationDate,
        Notes = e.Notes,
      }).ToList();

      return list;
    }

    public static List<PersonForSearchVm> MapForSearch(IQueryable<Person> en)
    {
      var list = en.Select(e => new PersonForSearchVm()
      {
        PersonId = e.PersonId,
        Name = e.Name,
        Surname = e.Surname,
        PersonalNumber = e.PersonalNumber,
        EmailAddress = e.EmailAddress,
        PhoneNumber = e.PhoneNumber,
      }).ToList();

      return list;
    }

    public static PersonVm Map(Person en)
    {
      var vm = new PersonVm()
      {
        PersonId = en.PersonId,
        Name = en.Name,
        Surname = en.Surname,
        PersonalNumber = en.PersonalNumber,
        PhoneNumber = en.PhoneNumber,
        EmailAddress = en.EmailAddress,
        BlackListFlag = en.BlackListFlag,
        RegistrationDate = en.RegistrationDate,
        Notes = en.Notes,
        AddressId = en.AddressId,
        Address = new AddressVm(),
      };

      return vm;
    }

    public static Person Map(PersonVm vm)
    {
      var en = new Person()
      {
        PersonId = vm.PersonId,
        Name = vm.Name,
        Surname = vm.Surname,
        PersonalNumber = vm.PersonalNumber,
        PhoneNumber = vm.PhoneNumber,
        EmailAddress = vm.EmailAddress,
        BlackListFlag = vm.BlackListFlag,
        RegistrationDate = vm.RegistrationDate,
        Notes = vm.Notes,
        AddressId = vm.Address != null ? vm.Address.AddressId : 0,
      };

      return en;
    }
  }
}