using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
  [Table("ingredients")]
  public class Ingredient
  {
    [Key]
    public long Id { get; set; }

    [MinLength(3)]
    [MaxLength(20)]
    public string Name { get; set; }
  }
}