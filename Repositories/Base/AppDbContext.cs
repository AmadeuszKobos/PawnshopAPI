using Entities;
using Entities.Summary;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<ItemRegister> ItemsRegister { get; set; }
    public DbSet<ItemHistory> ItemsHistories { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonRegister> PersonsRegister { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ItemHistoryRegister> ItemHistoryRegisters { get; set; }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Summary> Summaries { get; set; }
    public DbSet<UsersRegister> UsersRegisters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Summary>().HasNoKey();

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
  }
}