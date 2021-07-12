using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
  [Table("pizzas")]
  public class Pizza
  {
    public Pizza()
    {

    }

    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "Nome da Pizza é requerido")]
    [MaxLength(20)]
    [MinLength(3)]
    [DataType("nvarchar")]
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Ingredient> Ingredients { get; set; }
  }
}