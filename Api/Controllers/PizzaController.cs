using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  [Route("pizzas")]
  public class PizzaController : ControllerBase
  {

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> Get([FromServices] DataContext context, [FromQuery(Name = "ingredientId")] List<long> ingredientsId)
    {

      var models = await context.Pizzas

        .Where(x => x.Ingredients
        .Any(ingredient => ingredientsId.Count > 0 ? ingredientsId.Contains(ingredient.Id) : true))
        .AsNoTracking()
        .ToListAsync();

      return Ok(models);
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<ActionResult<Pizza>> GetById([FromServices] DataContext context, long id)
    {
      var model = await context.Pizzas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

      if (model == null)
      {
        return NotFound(new { message = "Pizza não encontrada." });
      }
      return Ok(model);
    }
    [Route("")]
    [HttpPost]
    public async Task<ActionResult<Pizza>> Post([FromServices] DataContext context, [FromBody] Pizza model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        context.Add(model);
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch
      {
        return BadRequest(new { message = "Não foi possível criar." });
      }

    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromServices] DataContext context, long id)
    {
      var model = await context.Pizzas.FirstOrDefaultAsync(x => x.Id == id);

      if (model == null)
      {
        return BadRequest(new { message = "Pizza não encontrada." });
      }

      try
      {
        context.Remove(model);
        await context.SaveChangesAsync();
        return Ok(new { message = "Pizza deletado." });
      }
      catch
      {
        return BadRequest(new { message = "Não foi possível deletar o ingrediente" });
      }
    }

    [Route("{id:long}")]
    [HttpPatch]
    public async Task<IActionResult> Patch([FromServices] DataContext context, [FromBody] Pizza model, long id)
    {
      if (model.Id != id)
        return BadRequest(new { message = "Id no corpo é diferente do id enviado por parametro." });

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        context.Entry<Pizza>(model).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return Ok(model);
      }
      catch (DbUpdateConcurrencyException)
      {
        return BadRequest(new { message = "Ocorreu um erro ao atualizar a entidade" });
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Ocorreu um erro inesperado" });
      }
    }

  }
}