using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("PersonsRegister")]
  public class PersonRegister
  {
    [Column("Id")]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [Column("Email")]
    public string? Email { get; set; } = string.Empty;

    [Column("PhoneNumber")]
    public string? PhoneNumber { get; set; } = string.Empty;

    [Column("BlacklistFlag")]
    public bool BlacklistFlag { get; set; }

    [Column("Pawned")]
    public int Pawned { get; set; }

    [Column("Notes")]
    public string Notes { get; set; } = string.Empty;
  }
}