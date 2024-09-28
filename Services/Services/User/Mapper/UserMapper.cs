using Entities;

namespace Services
{
  public partial class Mapper
  {
    public static UserVm Map(User entity)
    {
      var vm = new UserVm()
      {
        UserId = entity.UserId,
        Username = entity.Username,
        Password = entity.Password,
        PreviousPassword = entity.PreviousPassword,
        LastLogin = entity.LastLogin,
        Blocked = entity.Blocked,
        PersonId = entity.PersonId,
        RightId = entity.RightId,
      };

      return vm;
    }
  }
}