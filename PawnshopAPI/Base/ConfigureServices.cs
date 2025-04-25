using Repositories;
using Repositories.Repos;
using Repositoriess;
using Services;
using Services.Services;

namespace HomeAPI.DI
{
  public static partial class ConfigureServices
  {
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
      RegisterCustomDependencies(services);

      return services;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
      services.AddScoped<IPersonRepository, PersonRepository>();
      services.AddScoped<IPersonService, PersonService>();

      services.AddScoped<IAddressRepository, AddressRepository>();

      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserService, UserService>();

      services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
      services.AddScoped<IUserRegisterService, UserRegisterService>();

      services.AddScoped<IItemRepository, ItemRepository>();
      services.AddScoped<IItemService, ItemService>();

      services.AddScoped<IItemRegisterRepository, ItemRegisterRepository>();
      services.AddScoped<IItemRegisterService, ItemRegisterService>();

      services.AddScoped<IItemHistoryRepository, ItemHistoryRepository>();
      services.AddScoped<IItemHistoryService, ItemHistoryService>();

      services.AddScoped<IPersonRegisterRepository, PersonRegisterRepository>();
      services.AddScoped<IPersonRegisterService, PersonRegisterService>();

      services.AddScoped<IItemHistoryRegisterRepository, ItemHistoryRegisterRepository>();
      services.AddScoped<IItemHistoryRegisterService, ItemHistoryRegisterService>();

      services.AddScoped<IInformationRepository, InformationRepository>();
      services.AddScoped<IInformationService, InformationService>();

      services.AddScoped<ISummaryRepository, SummaryRepository>();
      services.AddScoped<ISummaryService, SummaryService>();
    }
  }
}