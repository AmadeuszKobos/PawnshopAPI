using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoriess
{
  public class InformationRepository : BaseRepository<Information>, IInformationRepository
  {
    public InformationRepository(AppDbContext context) : base(context)
    {
    }
  }
}