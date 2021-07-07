using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
  [Table("pizzas")]
  public class Pizza
  {
    public Pizza()
    {
      this.Ingredients = new HashSet<Ingredient>();
    }

    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "Nome da Pizza é requerido")]
    [MaxLength(20)]
    [MinLength(3)]
    [DataType("nvarchar")]
    public string Name { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; }
  }
}