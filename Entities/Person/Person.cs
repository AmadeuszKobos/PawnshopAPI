using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("Persons")]
  public class Person
  {
    [Column("PersonId")]
    public int PersonId { get; set; }

    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [Column("Surname")]
    public string Surname { get; set; } = string.Empty;

    [Column("PersonalNumber")]
    public string PersonalNumber { get; set; } = string.Empty;

    [Column("PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("EmailAddress")]
    public string EmailAddress { get; set; } = string.Empty;

    [Column("BlackListFlag")]
    public bool BlackListFlag { get; set; }

    [Column("RegistrationDate")]
    public DateTime RegistrationDate { get; set; }

    [Column("Notes")]
    public string Notes { get; set; } = string.Empty;

    [Column("AddressId")]
    public int? AddressId { get; set; }
  }
}