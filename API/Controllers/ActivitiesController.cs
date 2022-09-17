using Application.Activities;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
  private readonly IMediator _mediator;
  public ActivitiesController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<Activity>>> GetActivities()
  {
    return await _mediator.Send(new List.Query());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Activity>> GetActivity(Guid id)
  {
    return await _mediator.Send(new Find.Query { Id = id });
  }

  [HttpPost]
  public async Task<IActionResult> CreateActivity(Activity activity)
  {
    return Ok(await _mediator.Send(new Create.Command { Activity = activity }));
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> EditActivity(Guid id, Activity activity)
  {
    activity.Id = id;
    return Ok(await _mediator.Send(new Edit.Command { Activity = activity }));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteActivity(Guid id)
  {
    return Ok(await _mediator.Send(new Delete.Command { Id = id }));
  }
}