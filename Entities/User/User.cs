using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("Users")]
  public class User
  {
    [Column("UserId")]
    public int UserId { get; set; }

    [Column("Username")]
    public string? Username { get; set; }

    [Column("Password")]
    public string? Password { get; set; }

    [Column("PreviousPassword")]
    public string? PreviousPassword { get; set; }

    [Column("LastLogin")]
    public DateTime? LastLogin { get; set; }

    [Column("Blocked")]
    public bool Blocked { get; set; }

    [Column("PersonId")]
    public int? PersonId { get; set; }

    [Column("RightId")]
    public int? RightId { get; set; }

    [Column("Deleted")]
    public bool Deleted { get; set; }

    [Column("Notes")]
    public string Notes { get; set; } = string.Empty;
  }
}