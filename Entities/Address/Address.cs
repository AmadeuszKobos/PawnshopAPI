using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("Addresses")]
  public class Address
  {
    [Column("AddressId")]
    public int AddressId { get; set; }

    [Column("StreetAddress")]
    public string Street { get; set; } = string.Empty;

    [Column("City")]
    public string City { get; set; } = string.Empty;

    [Column("PostalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [Column("Country")]
    public string Country { get; set; } = string.Empty;
  }
}