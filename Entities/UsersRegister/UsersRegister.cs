using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("UsersRegister")]
  public class UsersRegister
  {
    [Key]
    [Column("UserId")]
    public int UserId { get; set; }

    [Column("Username")]
    public string Username { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [Column("Blocked")]
    public bool Blocked { get; set; }
  }
}