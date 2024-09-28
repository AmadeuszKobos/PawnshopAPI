using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class InformationService : IInformationService
  {
    private readonly IInformationRepository _informationRepo;

    public InformationService(IInformationRepository informationRepo)
    {
      _informationRepo = informationRepo;
    }

    public List<InformationVm> GetInformations()
    {
      return Mapper.Map(_informationRepo.GetAll());
    }

    public List<InformationVm> GetLastInformations()
    {
      return Mapper.Map(_informationRepo.GetAll().Take(3));
    }
  }
}