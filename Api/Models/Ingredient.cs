using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
  [Table("ingredients")]
  public class Ingredient
  {
    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo name é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve conter 3 caracteres no mínimo")]
    [MaxLength(20, ErrorMessage = "O nome deve conter 20 caracteres no máximo")]
    public string Name { get; set; }
  }
}