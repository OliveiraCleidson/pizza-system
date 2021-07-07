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
  [Route("ingredients")]
  public class IngredientController : ControllerBase
  {

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Ingredient>>> Get([FromServices] DataContext context)
    {
      var models = await context.Ingredients.AsNoTracking().ToListAsync();
      return Ok(models);
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<ActionResult<Ingredient>> GetById([FromServices] DataContext context, long id)
    {
      var model = await context.Ingredients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

      if (model == null)
      {
        return NotFound(new { message = "Ingrediente não encontrado." });
      }
      return Ok(model);
    }
    [Route("")]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> Post([FromServices] DataContext context, [FromBody] Ingredient model)
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
      var model = await context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);

      if (model == null)
      {
        return BadRequest(new { message = "Ingrediente não encontrado." });
      }

      try
      {
        context.Remove(model);
        await context.SaveChangesAsync();
        return Ok(new { message = "Ingrediente deletado." });
      }
      catch
      {
        return BadRequest(new { message = "Não foi possível deletar o ingrediente" });
      }
    }

    [Route("{id:long}")]
    [HttpPatch]
    public async Task<IActionResult> Patch([FromServices] DataContext context, [FromBody] Ingredient model, long id)
    {
      if (model.Id != id)
        return BadRequest(new { message = "Id no corpo é diferente do id enviado por parametro." });

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        context.Entry<Ingredient>(model).State = EntityState.Modified;
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