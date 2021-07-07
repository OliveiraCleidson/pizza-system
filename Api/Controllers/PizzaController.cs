using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [Route("pizza")]
  public class PizzaController : ControllerBase
  {

    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> Get()
    {
      return new List<Pizza>();
    }
    [Route("{id:long}")]
    [HttpGet]
    public async Task<ActionResult<Pizza>> GetById(long id)
    {
      return new Pizza() { Id = id };
    }
    [Route("")]
    [HttpPost]
    public async Task<ActionResult<Pizza>> Post([FromBody] Pizza model)
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
    public async Task<IActionResult> Patch([FromBody] Pizza model, long id)
    {
      if (model.Id != id)
        return new BadRequestResult();

      return new OkObjectResult(model);
    }
  }
}