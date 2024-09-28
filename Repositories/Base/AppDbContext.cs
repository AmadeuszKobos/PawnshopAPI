using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}