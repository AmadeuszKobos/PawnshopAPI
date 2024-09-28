using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  [Table("Informations")]
  public class Information
  {
    [Key]
    [Column("InfoId")]
    public int Id { get; set; }

    [Column("Type")]
    public string Type { get; set; } = string.Empty;

    [Column("Content")]
    public string Content { get; set; } = string.Empty;
  }
}