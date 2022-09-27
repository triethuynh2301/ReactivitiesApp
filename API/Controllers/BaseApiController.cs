using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
  protected ActionResult HandleResult<T>(Result<T> result)
  {
    // no result found -> not found
    if (result == null) return NotFound();

    // success if no errors and with data
    if (result.IsSuccess && result.Value != null)
      return Ok(result.Value);

    // if status is success but no data -> not found
    if (result.IsSuccess && result.Value == null)
      return NotFound();

    // any other case would be errors
    return BadRequest(result.Error);
  }
}