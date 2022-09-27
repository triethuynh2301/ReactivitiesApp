using Api.Controllers;
using Application.Activities;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
  private readonly IMediator _mediator;
  public ActivitiesController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> GetActivities()
  {
    return HandleResult(await _mediator.Send(new List.Query()));
  }

  [HttpGet("{id}")]
  [Authorize]
  public async Task<IActionResult> GetActivity(Guid id)
  {
    return HandleResult(await _mediator.Send(new Find.Query { Id = id }));
  }

  [HttpPost]
  public async Task<IActionResult> CreateActivity(Activity activity)
  {
    return HandleResult(await _mediator.Send(new Create.Command { Activity = activity }));
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> EditActivity(Guid id, Activity activity)
  {
    activity.Id = id;
    // return Ok(await _mediator.Send(new Edit.Command { Activity = activity }));
    return HandleResult(await _mediator.Send(new Edit.Command { Activity = activity }));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteActivity(Guid id)
  {
    return HandleResult(await _mediator.Send(new Delete.Command { Id = id }));
  }
}
