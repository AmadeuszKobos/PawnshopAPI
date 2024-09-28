using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
  [Table("Items")]
  public class Item
  {
    [Key]
    [Column("ItemId")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; } = string.Empty;

    [Column("Producer")]
    public string Producer { get; set; } = string.Empty;

    //[Column("Picture")]
    //public int Picture { get; set; }

    [Column("PawnshopOwnershipDate")]
    public DateTime? PawnshopOwnershipDate { get; set; }

    [Column("Deleted")]
    public bool? Deleted { get; set; }
  }
}