using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
  [Table("ingredients")]
  public class Ingredient
  {
    public Ingredient()
    {
      this.Pizzas = new HashSet<Pizza>();
    }

    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo name é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter 3 caracteres no mínimo")]
    [MaxLength(20, ErrorMessage = "O nome deve conter 20 caracteres no máximo")]
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Pizza> Pizzas { get; set; }
  }
}