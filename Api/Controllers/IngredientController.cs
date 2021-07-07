using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("ingredients")]
  public class IngredientController : ControllerBase
  {

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Ingredient>>> Get()
    {
      return new List<Ingredient>();
    }
    [Route("{id:long}")]
    [HttpGet]
    public async Task<ActionResult<Ingredient>> GetById(long id)
    {
      return new Ingredient() { Id = id };
    }
    [Route("")]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> Post([FromBody] Ingredient model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      return new OkObjectResult(model);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
      return new OkObjectResult(new { id = id });
    }
    [Route("{id:long}")]
    [HttpPatch]
    public async Task<IActionResult> Patch([FromBody] Ingredient model, long id)
    {
      if (model.Id != id)
        return new BadRequestResult();

      return new OkObjectResult(model);
    }
  }
}