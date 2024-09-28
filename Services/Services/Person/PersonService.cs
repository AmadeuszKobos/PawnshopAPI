using Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using Repositories;
using Repositories.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository _repo;
    private readonly IAddressRepository _addressRepo;
    public readonly IItemHistoryRepository _itemHistoryRepo;

    public PersonService(IPersonRepository repo, IAddressRepository addressRepo, IItemHistoryRepository itemHistoryRepo)
    {
      _repo = repo;
      _addressRepo = addressRepo;
      _itemHistoryRepo = itemHistoryRepo;
    }

    public PersonVm GetPerson(int personId)
    {
      var personVm = Mapper.Map(_repo.FirstOrDefault(x => x.PersonId == personId));
      personVm.Address = Mapper.Map(_addressRepo.FirstOrDefault(x => x.AddressId == personVm.AddressId));

      return personVm;
    }

    public PersonVm GetPersonForItem(int itemId)
    {
      var itemLastOwnerId = _itemHistoryRepo.OrderByDescending(x => x.OperationDate).FirstOrDefault(x => x.ItemId == itemId && (x.OperationTypeId == (int)OperationTypeEnum.Pawn || x.OperationTypeId == (int)OperationTypeEnum.Purchase))?.PersonId;

      if(itemLastOwnerId != null)
      {
        return Mapper.Map(_repo.FirstOrDefault(x => x.PersonId == itemLastOwnerId));
      }
      else
      {
        throw new Exception("Nie odnaleziono ostatniego właściciela");
      }

    }

    public List<PersonForSearchVm> GetPersonsForSearch(string searchValue)
    {
      return Mapper.MapForSearch(_repo.GetPersonsForSearch(searchValue));
    }

    public PersonVm AddOrUpdatePerson(PersonVm personVm)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      var address = new Address();

      var person = Mapper.Map(personVm);

      if (personVm.Address != null)
      {
        address = Mapper.Map(personVm.Address);
      }

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _addressRepo.AddOrUpdate(address.AddressId, address);

        person.AddressId = address.AddressId;

        _repo.AddOrUpdate(person.PersonId, person);

        tran.Complete();
      }

      personVm = Mapper.Map(person);
      personVm.Address = Mapper.Map(address);

      return personVm;
    }

    public void UpdateBlacklistFlag(int personId, bool currentBlacklistFlag)
    {
      var options = new TransactionOptions
      {
        IsolationLevel = IsolationLevel.ReadCommitted,
        Timeout = TransactionManager.DefaultTimeout
      };

      using (var tran = new TransactionScope(TransactionScopeOption.Required, options))
      {
        _repo.UpdateSingleColumn(x => x.PersonId == personId, x => x.BlackListFlag, !currentBlacklistFlag);

        tran.Complete();
      }
    }


  }
}